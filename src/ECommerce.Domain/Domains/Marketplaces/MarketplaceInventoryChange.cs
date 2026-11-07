using ECommerce.Core.Domain;

namespace ECommerce.Marketplaces;

/// <summary>
/// Stok/fiyat outbox kaydı: varyant değiştiğinde aynı kayıtta yazılır, arka plan işi pazaryerine gönderir.
/// </summary>
public class MarketplaceInventoryChange : AggregateRoot<int>
{
    public int VariantId { get; private set; }

    public DateTime? ProcessedAt { get; private set; }

    public string? Error { get; private set; }

    public static MarketplaceInventoryChange For(int variantId) => new() { VariantId = variantId };

    public void MarkProcessed(DateTime now, string? error = null)
    {
        ProcessedAt = now;
        Error = error;
    }
}
