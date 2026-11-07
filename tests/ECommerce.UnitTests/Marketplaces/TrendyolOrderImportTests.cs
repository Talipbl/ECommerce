using ECommerce.Application.Marketplaces;
using ECommerce.Application.Marketplaces.Trendyol;
using ECommerce.Catalog;
using ECommerce.Ordering;
using ECommerce.Persistence;
using ECommerce.UnitTests.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Time.Testing;
using NSubstitute;
using Trendyol.Client.Orders;

namespace ECommerce.UnitTests.Marketplaces;

public sealed class TrendyolOrderImportTests : IAsyncLifetime
{
    private static readonly DateTimeOffset Now = new(2026, 11, 7, 12, 0, 0, TimeSpan.Zero);
    private readonly CatalogTestDb _db = new();
    private readonly ITrendyolOrderService _trendyol = Substitute.For<ITrendyolOrderService>();
    private readonly FakeTimeProvider _clock = new(Now);
    private Product _product = null!;
    private static CancellationToken Ct => TestContext.Current.CancellationToken;

    private TrendyolOrderImportService Service => new(_trendyol, new EfRepository<Order>(_db.Context), _db.Products, _db.Variants, _db.Context, _clock);

    public async ValueTask InitializeAsync()
    {
        var brand = await _db.AddAsync(Brand.Create("Acme", "acme"));
        var category = await _db.AddAsync(Category.Create("Tişört", "tisort", null, null, 0));
        _product = await _db.AddProductAsync("Basic Tişört", brand, category, price: 150m, stock: 5);
    }

    private static ShipmentPackage Package(long id, string status, params ShipmentLine[] lines) => new()
    {
        ShipmentPackageId = id,
        OrderNumber = "10654411111",
        Status = status,
        OrderDate = Now.AddHours(-2).ToUnixTimeMilliseconds(),
        CustomerFirstName = "Ali",
        CustomerLastName = "Veli",
        CustomerEmail = "pf+abc@trendyolmail.com",
        CargoProviderName = "Trendyol Express",
        CargoTrackingNumber = 7330000000001,
        ShipmentAddress = new TrendyolAddress { FullName = "Ali Veli", Phone = "05551112233", City = "İstanbul", District = "Kadıköy", FullAddress = "Moda Cd. No:1" },
        Lines = lines.Length > 0 ? lines : [new ShipmentLine { LineId = 555, Barcode = "BRK-basic-tisort", ProductName = "Basic Tişört", Quantity = 2, LineGrossAmount = 300m, LineTotalDiscount = 50m, VatRate = 20 }]
    };

    private void Returns(params ShipmentPackage[] packages) =>
        _trendyol.GetPackagesAsync(Arg.Any<OrderPackagesQuery>(), Arg.Any<CancellationToken>())
            .Returns(MarketplaceResult<ShipmentPackagePage>.Success(new ShipmentPackagePage(0, 200, packages.Length, 1, packages)));

    private Task<int> StockAsync() => _db.Context.ProductVariants.Select(v => v.StockQuantity).SingleAsync(Ct);

    [Fact]
    public async Task New_package_is_imported_once_and_decreases_stock()
    {
        Returns(Package(3330000001, "Created"));

        var first = await Service.ImportAsync(Ct);
        var second = await Service.ImportAsync(Ct);

        first.Imported.ShouldBe(1);
        second.Imported.ShouldBe(0);
        var order = await _db.Context.Orders.SingleAsync(Ct);
        order.Channel.ShouldBe(OrderChannel.Trendyol);
        order.ExternalReference.ShouldBe("3330000001");
        order.OrderNumber.ShouldBe("TY3330000001");
        order.Status.ShouldBe(OrderStatus.Confirmed);
        order.Total.ShouldBe(250m);
        order.Lines.Single().VariantId.ShouldBe(_product.Variants.Single().Id);
        order.ShippingAddress.City.ShouldBe("İstanbul");
        (await StockAsync()).ShouldBe(3);
    }

    [Fact]
    public async Task Unknown_barcode_is_imported_without_stock_change()
    {
        Returns(Package(3330000002, "Created", new ShipmentLine { LineId = 1, Barcode = "YABANCI", ProductName = "Bilinmeyen", Quantity = 1, LineGrossAmount = 100m }));

        await Service.ImportAsync(Ct);

        (await _db.Context.Orders.SingleAsync(Ct)).Lines.Single().VariantId.ShouldBeNull();
        (await StockAsync()).ShouldBe(5);
    }

    [Fact]
    public async Task Later_status_changes_are_mirrored()
    {
        Returns(Package(3330000003, "Created"));
        await Service.ImportAsync(Ct);

        Returns(Package(3330000003, "Shipped"));
        var result = await Service.ImportAsync(Ct);

        result.Updated.ShouldBe(1);
        var order = await _db.Context.Orders.SingleAsync(Ct);
        order.Status.ShouldBe(OrderStatus.Shipped);
        order.TrackingNumber.ShouldBe("7330000000001");
    }

    [Fact]
    public async Task Cancellation_on_trendyol_cancels_local_order_and_restores_stock()
    {
        Returns(Package(3330000004, "Created"));
        await Service.ImportAsync(Ct);
        (await StockAsync()).ShouldBe(3);

        Returns(Package(3330000004, "Cancelled"));
        await Service.ImportAsync(Ct);

        (await _db.Context.Orders.SingleAsync(Ct)).Status.ShouldBe(OrderStatus.Cancelled);
        (await StockAsync()).ShouldBe(5);
    }

    [Fact]
    public async Task Package_first_seen_as_cancelled_is_skipped()
    {
        Returns(Package(3330000005, "Cancelled"));

        var result = await Service.ImportAsync(Ct);

        result.Imported.ShouldBe(0);
        (await _db.Context.Orders.CountAsync(Ct)).ShouldBe(0);
    }

    [Fact]
    public async Task Stock_never_goes_negative_when_marketplace_sells_more_than_local_stock()
    {
        Returns(Package(3330000006, "Created", new ShipmentLine { LineId = 1, Barcode = "BRK-basic-tisort", ProductName = "Basic Tişört", Quantity = 9, LineGrossAmount = 1350m }));

        await Service.ImportAsync(Ct);

        (await StockAsync()).ShouldBe(0);
    }

    [Fact]
    public async Task All_pages_of_the_last_14_days_are_read()
    {
        _trendyol.GetPackagesAsync(Arg.Is<OrderPackagesQuery>(q => q.Page == 0), Arg.Any<CancellationToken>())
            .Returns(MarketplaceResult<ShipmentPackagePage>.Success(new ShipmentPackagePage(0, 200, 2, 2, [Package(1, "Created")])));
        _trendyol.GetPackagesAsync(Arg.Is<OrderPackagesQuery>(q => q.Page == 1), Arg.Any<CancellationToken>())
            .Returns(MarketplaceResult<ShipmentPackagePage>.Success(new ShipmentPackagePage(1, 200, 2, 2, [Package(2, "Created")])));

        var result = await Service.ImportAsync(Ct);

        result.Imported.ShouldBe(2);
        await _trendyol.Received().GetPackagesAsync(
            Arg.Is<OrderPackagesQuery>(q => q.StartDate == Now.AddDays(-14) && q.EndDate == Now && q.Size == 200), Arg.Any<CancellationToken>());
    }

    public ValueTask DisposeAsync() => _db.DisposeAsync();
}
