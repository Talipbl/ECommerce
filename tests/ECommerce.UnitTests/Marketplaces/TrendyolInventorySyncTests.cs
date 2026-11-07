using ECommerce.Application.Marketplaces;
using ECommerce.Application.Marketplaces.Trendyol;
using ECommerce.Catalog;
using ECommerce.Marketplaces;
using ECommerce.Persistence;
using ECommerce.UnitTests.Catalog;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using Trendyol.Client.Products;

namespace ECommerce.UnitTests.Marketplaces;

public sealed class TrendyolInventorySyncTests : IAsyncLifetime
{
    private readonly CatalogTestDb _db = new();
    private readonly ITrendyolProductService _trendyol = Substitute.For<ITrendyolProductService>();
    private Product _listed = null!;
    private Product _notListed = null!;
    private static CancellationToken Ct => TestContext.Current.CancellationToken;

    private TrendyolInventorySyncService Service => new(
        new EfRepository<MarketplaceInventoryChange>(_db.Context), new EfRepository<MarketplaceListing>(_db.Context),
        _db.Products, _db.Variants, _db.Context, _trendyol);

    public async ValueTask InitializeAsync()
    {
        var brand = await _db.AddAsync(Brand.Create("Acme", "acme"));
        var category = await _db.AddAsync(Category.Create("Tişört", "tisort", null, null, 0));
        _listed = await _db.AddProductAsync("Listelenen", brand, category, price: 150m, stock: 5);
        _notListed = await _db.AddProductAsync("Listelenmeyen", brand, category, price: 90m, stock: 2);

        var listing = MarketplaceListing.Create(MarketplaceNames.Trendyol, _listed.Id);
        listing.MarkSubmitted("b", DateTime.UtcNow);
        listing.ApplyBatchResult(true, [], DateTime.UtcNow);
        await _db.AddAsync(listing);

        _trendyol.UpdatePriceAndInventoryAsync(Arg.Any<UpdatePriceInventoryRequest>(), Arg.Any<CancellationToken>())
            .Returns(MarketplaceResult<BatchAcceptedDto>.Success(new BatchAcceptedDto("pi-1", MarketplaceBatchOperation.PriceInventory, 1)));
    }

    [Fact]
    public async Task Price_stock_and_activity_changes_are_recorded_but_name_changes_are_not()
    {
        _listed.Variants.Single().SetStock(4);
        await _db.Context.SaveChangesAsync(Ct);
        _notListed.Variants.Single().ChangePrice(95m, null);
        await _db.Context.SaveChangesAsync(Ct);
        _listed.UpdateDetails("Yeni Ad", _listed.Slug, _listed.ProductCode, _listed.BrandId, _listed.CategoryId, 20, null);
        await _db.Context.SaveChangesAsync(Ct);

        (await _db.Context.MarketplaceInventoryChanges.Select(c => c.VariantId).ToListAsync(Ct))
            .ShouldBe([_listed.Variants.Single().Id, _notListed.Variants.Single().Id], ignoreOrder: true);
    }

    [Fact]
    public async Task Only_variants_of_accepted_listings_are_sent_with_current_values()
    {
        _listed.Variants.Single().SetStock(3);
        _notListed.Variants.Single().SetStock(1);
        await _db.Context.SaveChangesAsync(Ct);

        var processed = await Service.SyncPendingAsync(Ct);

        processed.ShouldBe(2);
        await _trendyol.Received(1).UpdatePriceAndInventoryAsync(Arg.Is<UpdatePriceInventoryRequest>(r =>
            r.Items.Count == 1 && r.Items[0].Barcode == "BRK-listelenen" && r.Items[0].Quantity == 3 && r.Items[0].SalePrice == 150m && r.Items[0].ListPrice == 150m),
            Arg.Any<CancellationToken>());
        (await _db.Context.MarketplaceInventoryChanges.CountAsync(c => c.ProcessedAt == null, Ct)).ShouldBe(0);
    }

    [Fact]
    public async Task Unpublished_product_is_sent_with_zero_stock()
    {
        _listed.Unpublish();
        _listed.Variants.Single().SetStock(4);
        await _db.Context.SaveChangesAsync(Ct);

        await Service.SyncPendingAsync(Ct);

        await _trendyol.Received(1).UpdatePriceAndInventoryAsync(Arg.Is<UpdatePriceInventoryRequest>(r => r.Items.Single().Quantity == 0), Arg.Any<CancellationToken>());
    }

    [Fact]
    public async Task Transient_failure_keeps_changes_pending()
    {
        _trendyol.UpdatePriceAndInventoryAsync(Arg.Any<UpdatePriceInventoryRequest>(), Arg.Any<CancellationToken>())
            .Returns(MarketplaceResult<BatchAcceptedDto>.Failure(new MarketplaceError(MarketplaceErrorKind.Unavailable, 503, [])));
        _listed.Variants.Single().SetStock(2);
        await _db.Context.SaveChangesAsync(Ct);

        var processed = await Service.SyncPendingAsync(Ct);

        processed.ShouldBe(0);
        (await _db.Context.MarketplaceInventoryChanges.CountAsync(c => c.ProcessedAt == null, Ct)).ShouldBe(1);
    }

    [Fact]
    public async Task Rejected_request_is_not_retried_forever()
    {
        _trendyol.UpdatePriceAndInventoryAsync(Arg.Any<UpdatePriceInventoryRequest>(), Arg.Any<CancellationToken>())
            .Returns(MarketplaceResult<BatchAcceptedDto>.Failure(new MarketplaceError(MarketplaceErrorKind.Validation, 400, ["15 dakika boyunca aynı isteği tekrarlı olarak atamazsınız!"])));
        _listed.Variants.Single().SetStock(2);
        await _db.Context.SaveChangesAsync(Ct);

        await Service.SyncPendingAsync(Ct);

        var change = await _db.Context.MarketplaceInventoryChanges.SingleAsync(Ct);
        change.ProcessedAt.ShouldNotBeNull();
        change.Error!.ShouldContain("15 dakika");
    }

    public ValueTask DisposeAsync() => _db.DisposeAsync();
}
