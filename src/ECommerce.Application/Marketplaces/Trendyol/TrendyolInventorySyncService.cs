using ECommerce.Application.Shopping;
using ECommerce.Catalog;
using ECommerce.Core.Persistence;
using ECommerce.Marketplaces;
using Trendyol.Client.Products;

namespace ECommerce.Application.Marketplaces.Trendyol;

public interface ITrendyolInventorySyncService
{
    Task<int> SyncPendingAsync(CancellationToken cancellationToken = default);
}

/// <summary>
/// Outbox'taki stok/fiyat değişikliklerini Trendyol'da kabul edilmiş ürünler için toplu gönderir.
/// </summary>
public class TrendyolInventorySyncService(
    IRepository<MarketplaceInventoryChange> changes,
    IRepository<MarketplaceListing> listings,
    IRepository<Product> products,
    IRepository<ProductVariant> variants,
    IUnitOfWork unitOfWork,
    ITrendyolProductService trendyol) : ITrendyolInventorySyncService
{
    private const int BatchSize = 1000;

    public async Task<int> SyncPendingAsync(CancellationToken cancellationToken = default)
    {
        var pending = await changes.ListAsync(q => q.Where(c => c.ProcessedAt == null).OrderBy(c => c.Id).Take(BatchSize), cancellationToken);
        if (pending.Count == 0)
            return 0;

        var variantIds = pending.Select(c => c.VariantId).Distinct().ToList();
        var found = await CartService.LoadVariantsAsync(variants, products, variantIds, cancellationToken);
        var productIds = found.Values.Select(v => v.Product.Id).Distinct().ToList();
        var syncable = (await listings.ListAsync(l => l.Marketplace == MarketplaceNames.Trendyol && productIds.Contains(l.ProductId), cancellationToken))
            .Where(l => l.IsSyncable)
            .Select(l => l.ProductId)
            .ToHashSet();

        // Satıştan kalkan ürün veya varyant pazaryerinde 0 stokla satışa kapatılır.
        var items = found.Values
            .Where(v => syncable.Contains(v.Product.Id))
            .Select(v => new PriceInventoryItem(
                v.Variant.Barcode,
                v.IsPurchasable ? Math.Min(v.Variant.StockQuantity, 20000) : 0,
                v.Variant.Price,
                v.Variant.ListPrice ?? v.Variant.Price))
            .ToList();

        var now = DateTime.UtcNow;
        if (items.Count > 0)
        {
            var result = await trendyol.UpdatePriceAndInventoryAsync(new UpdatePriceInventoryRequest(items), cancellationToken);
            if (!result.Succeeded && result.Error!.Kind is MarketplaceErrorKind.Unavailable or MarketplaceErrorKind.RateLimited or MarketplaceErrorKind.Unauthorized)
                return 0;

            var error = result.Succeeded ? null : string.Join("; ", result.Error!.Messages);
            foreach (var change in pending)
                change.MarkProcessed(now, error);
        }
        else
        {
            foreach (var change in pending)
                change.MarkProcessed(now);
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return pending.Count;
    }
}
