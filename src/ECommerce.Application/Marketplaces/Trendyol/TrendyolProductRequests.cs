using ECommerce.Marketplaces;
using Trendyol.Client.Products;

namespace ECommerce.Application.Marketplaces.Trendyol;

public record CreateTrendyolProductsRequest(IReadOnlyList<CreateProductItem> Items);

public record UpdateTrendyolContentRequest(IReadOnlyList<ApprovedContentUpdateItem> Items);

public record UpdateUnapprovedTrendyolProductsRequest(IReadOnlyList<UnapprovedProductUpdateItem> Items);

public record UpdatePriceInventoryRequest(IReadOnlyList<PriceInventoryItem> Items);

public record DeleteTrendyolProductsRequest(IReadOnlyList<string> Barcodes);

public record BatchAcceptedDto(string BatchRequestId, MarketplaceBatchOperation Operation, int ItemCount);

public record PagedResult<T>(int Page, int Size, int TotalElements, IReadOnlyList<T> Content)
{
    public int TotalPages => Size == 0 ? 0 : (int)Math.Ceiling(TotalElements / (double)Size);
}
