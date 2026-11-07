namespace ECommerce.Application.Catalog;

public interface IMediaUrlBuilder
{
    string ToPublicUrl(string path);
}

public record SaveCategoryRequest(string Name, string? Slug, int? ParentId, string? Description, int SortOrder, bool IsActive);

public record CategoryDto(int Id, string Name, string Slug, int? ParentId, string? Description, int SortOrder, bool IsActive);

public record CategoryTreeDto(int Id, string Name, string Slug, int? ParentId, int SortOrder, bool IsActive, IReadOnlyList<CategoryTreeDto> Children);

public record SaveBrandRequest(string Name, string? Slug, bool IsActive);

public record BrandDto(int Id, string Name, string Slug, bool IsActive);

public record VariantAttributeDto(string Name, string Value);

public record VariantInput(string Sku, string Barcode, decimal Price, decimal? ListPrice, int StockQuantity, IReadOnlyList<VariantAttributeDto> Attributes);

public record CreateProductRequest(
    string Name,
    string? Slug,
    string ProductCode,
    int BrandId,
    int CategoryId,
    int VatRate,
    string? Description,
    IReadOnlyList<VariantInput> Variants);

public record UpdateProductRequest(string Name, string Slug, string ProductCode, int BrandId, int CategoryId, int VatRate, string? Description);

public record UpdateVariantRequest(decimal Price, decimal? ListPrice, int StockQuantity, bool IsActive, IReadOnlyList<VariantAttributeDto> Attributes);

public record ProductAdminQuery(string? Search, int? CategoryId, int? BrandId, bool? IsActive, int Page = 0, int Size = 20);

public record ProductListItemDto(
    int Id,
    string Name,
    string Slug,
    string ProductCode,
    int BrandId,
    int CategoryId,
    bool IsActive,
    int VariantCount,
    int TotalStock,
    decimal? MinPrice,
    string? ImageUrl);

public record VariantDto(int Id, string Sku, string Barcode, decimal Price, decimal? ListPrice, int StockQuantity, bool IsActive, IReadOnlyList<VariantAttributeDto> Attributes);

public record ProductImageDto(int Id, string Url, string? AltText, int SortOrder);

public record ProductDetailDto(
    int Id,
    string Name,
    string Slug,
    string ProductCode,
    int BrandId,
    int CategoryId,
    int VatRate,
    string? Description,
    bool IsActive,
    IReadOnlyList<VariantDto> Variants,
    IReadOnlyList<ProductImageDto> Images);

public enum StoreProductSort
{
    Newest,
    PriceAscending,
    PriceDescending,
    Name
}

public record StoreProductQuery
{
    public string? CategorySlug { get; init; }
    public string? BrandSlug { get; init; }
    public string? Search { get; init; }
    public decimal? MinPrice { get; init; }
    public decimal? MaxPrice { get; init; }
    public bool InStockOnly { get; init; }
    public StoreProductSort Sort { get; init; } = StoreProductSort.Newest;
    public int Page { get; init; }
    public int Size { get; init; } = 24;
}

public record StoreCategoryDto(int Id, string Name, string Slug, IReadOnlyList<StoreCategoryDto> Children);

public record StoreCategoryRef(string Name, string Slug);

public record StoreProductCard(int Id, string Name, string Slug, string BrandName, decimal MinPrice, decimal? ListPrice, bool InStock, string? ImageUrl);

public record StoreVariantDto(int Id, decimal Price, decimal? ListPrice, bool InStock, IReadOnlyList<VariantAttributeDto> Attributes);

public record StoreProductDetail(
    int Id,
    string Name,
    string Slug,
    string? Description,
    string BrandName,
    string BrandSlug,
    IReadOnlyList<StoreCategoryRef> CategoryPath,
    int VatRate,
    IReadOnlyList<string> Images,
    IReadOnlyList<StoreVariantDto> Variants);
