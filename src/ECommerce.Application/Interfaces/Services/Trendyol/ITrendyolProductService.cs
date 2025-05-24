using ECommerce.Core.Application;
using Trendyol.Client;

namespace ECommerce.Trendyol;

public interface ITrendyolProductService
{
    Task<IDataResult<ProductsResponseDTO>> GetProductsAsync(ProductQueryParametersDTO parameters);
    Task<IDataResult<TrendyolErrorResultDTO>> CreateProductsAsync(List<ProductRequestDTO> products);
    Task<IDataResult<TrendyolErrorResultDTO>> CreateProductAsync(ProductRequestDTO product);
    Task<IDataResult<TrendyolErrorResultDTO>> UpdatePriceAndInventoryAsync(List<PriceAndInventoryUpdateRequestDTO> priceAndInventories);
    Task<IDataResult<TrendyolErrorResultDTO>> DeleteProductAsync(List<string> productBarcodes);
    Task<IDataResult<List<BrandResponseDTO>>> GetBrandsAsync();
    Task<IDataResult<List<BrandResponseDTO>>> GetBrandsAsync(string search, int size = 100);
    Task<IDataResult<List<CategoryResponseDTO>>> GetCategoriesAsync(string search, int size = 100);
    Task<IDataResult<TrendyolErrorResultDTO>> UpdateProductAsync(ProductRequestDTO product);

}
