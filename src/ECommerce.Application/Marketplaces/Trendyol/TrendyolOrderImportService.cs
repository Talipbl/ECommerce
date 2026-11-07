using ECommerce.Catalog;
using ECommerce.Core.Persistence;
using ECommerce.Ordering;
using Trendyol.Client.Orders;

namespace ECommerce.Application.Marketplaces.Trendyol;

public record OrderImportSummary(int Imported, int Updated, int Skipped, string? Error = null);

public interface ITrendyolOrderImportService
{
    Task<OrderImportSummary> ImportAsync(CancellationToken cancellationToken = default);
}

/// <summary>
/// Son 14 günün Trendyol paketlerini yerel siparişe çevirir (paket numarasıyla idempotent) ve durumlarını yansıtır.
/// </summary>
public class TrendyolOrderImportService(
    ITrendyolOrderService trendyol,
    IRepository<Order> orders,
    IRepository<Product> products,
    IRepository<ProductVariant> variants,
    IUnitOfWork unitOfWork,
    TimeProvider clock) : ITrendyolOrderImportService
{
    public static readonly TimeSpan Window = TrendyolOrderService.MaxDateRange;
    private const int PageSize = TrendyolOrderService.MaxPageSize;
    private const int MaxPages = TrendyolOrderService.MaxAccessibleRecords / PageSize;

    public async Task<OrderImportSummary> ImportAsync(CancellationToken cancellationToken = default)
    {
        var now = clock.GetUtcNow();
        int imported = 0, updated = 0, skipped = 0;

        for (var page = 0; page < MaxPages; page++)
        {
            var response = await trendyol.GetPackagesAsync(new OrderPackagesQuery(now - Window, now, null, null, null, page, PageSize), cancellationToken);
            if (!response.Succeeded)
                return new OrderImportSummary(imported, updated, skipped, string.Join("; ", response.Error!.Messages.DefaultIfEmpty(response.Error.Kind.ToString())));

            foreach (var package in response.Value!.Content ?? [])
            {
                switch (await ProcessAsync(package, now.UtcDateTime, cancellationToken))
                {
                    case Outcome.Imported: imported++; break;
                    case Outcome.Updated: updated++; break;
                    default: skipped++; break;
                }
            }

            await unitOfWork.SaveChangesAsync(cancellationToken);
            if (page + 1 >= response.Value.TotalPages)
                break;
        }

        return new OrderImportSummary(imported, updated, skipped);
    }

    private enum Outcome { Imported, Updated, Skipped }

    private async Task<Outcome> ProcessAsync(ShipmentPackage package, DateTime now, CancellationToken cancellationToken)
    {
        var reference = package.ShipmentPackageId.ToString();
        var target = MapStatus(package.Status);
        var tracking = package.CargoTrackingNumber?.ToString();
        var existing = await orders.FirstOrDefaultAsync(o => o.Channel == OrderChannel.Trendyol && o.ExternalReference == reference, cancellationToken);

        if (existing is not null)
        {
            if (target is null || !existing.ApplyMarketplaceStatus(target.Value, package.CargoProviderName, tracking, now))
                return Outcome.Skipped;
            if (target == OrderStatus.Cancelled)
                await AdjustStockAsync(existing.Lines.Where(l => l.VariantId is not null).Select(l => (l.VariantId!.Value, l.Quantity)), increase: true, cancellationToken);
            return Outcome.Updated;
        }

        if (target is null or OrderStatus.Cancelled)
            return Outcome.Skipped;

        var lines = package.Lines ?? [];
        var barcodes = lines.Select(l => l.Barcode).OfType<string>().Distinct().ToList();
        var byBarcode = (await variants.ListAsync(v => barcodes.Contains(v.Barcode), cancellationToken)).ToDictionary(v => v.Barcode);

        var inputs = lines.Select(l =>
        {
            var variant = l.Barcode is null ? null : byBarcode.GetValueOrDefault(l.Barcode);
            var net = l.LineGrossAmount - l.LineTotalDiscount;
            var unitPrice = l.Quantity > 0 && net > 0 ? Math.Round(net / l.Quantity, 2) : l.LineUnitPrice;
            return new OrderLineInput(variant?.Id, variant?.ProductId, l.ProductName ?? l.Barcode ?? "Ürün", null, l.Barcode ?? "-", l.StockCode,
                unitPrice, Math.Max(l.Quantity, 1), (int)(l.VatRate ?? 0));
        }).ToList();

        var address = package.ShipmentAddress ?? new TrendyolAddress();
        var customerName = $"{package.CustomerFirstName} {package.CustomerLastName}".Trim();
        var order = Order.ImportMarketplaceOrder(
            $"TY{reference}", OrderChannel.Trendyol, reference, package.CustomerEmail ?? "-", customerName.Length > 0 ? customerName : "Trendyol müşterisi",
            new OrderAddress(address.FullName ?? customerName, address.Phone ?? "-", address.City ?? "-", address.District ?? "-",
                address.FullAddress ?? "-", address.PostalCode),
            inputs, DateTimeOffset.FromUnixTimeMilliseconds(package.OrderDate).UtcDateTime);

        if (target != OrderStatus.Confirmed)
            order.ApplyMarketplaceStatus(target.Value, package.CargoProviderName, tracking, now);

        orders.Add(order);
        await AdjustStockAsync(inputs.Where(i => i.VariantId is not null).Select(i => (i.VariantId!.Value, i.Quantity)), increase: false, cancellationToken);
        return Outcome.Imported;
    }

    // Satış pazaryerinde gerçekleştiği için yerel stok yetmese de sipariş alınır; stok sıfırın altına inmez.
    private async Task AdjustStockAsync(IEnumerable<(int VariantId, int Quantity)> lines, bool increase, CancellationToken cancellationToken)
    {
        var quantities = lines.GroupBy(l => l.VariantId).ToDictionary(g => g.Key, g => g.Sum(l => l.Quantity));
        if (quantities.Count == 0)
            return;

        var productIds = await variants.ListAsync(q => q.Where(v => quantities.Keys.Contains(v.Id)).Select(v => v.ProductId), cancellationToken);
        foreach (var product in await products.ListAsync(p => productIds.Contains(p.Id), cancellationToken))
        {
            foreach (var variant in product.Variants.Where(v => quantities.ContainsKey(v.Id)))
            {
                var quantity = quantities[variant.Id];
                if (increase)
                    variant.IncreaseStock(quantity);
                else
                    variant.SetStock(Math.Max(0, variant.StockQuantity - quantity));
            }
        }
    }

    internal static OrderStatus? MapStatus(string? status) => status switch
    {
        ShipmentPackageStatuses.Created or ShipmentPackageStatuses.Awaiting or ShipmentPackageStatuses.Verified => OrderStatus.Confirmed,
        ShipmentPackageStatuses.Picking or ShipmentPackageStatuses.Invoiced => OrderStatus.Preparing,
        ShipmentPackageStatuses.Shipped or ShipmentPackageStatuses.AtCollectionPoint => OrderStatus.Shipped,
        ShipmentPackageStatuses.Delivered => OrderStatus.Delivered,
        ShipmentPackageStatuses.Cancelled or ShipmentPackageStatuses.UnSupplied => OrderStatus.Cancelled,
        _ => null
    };
}
