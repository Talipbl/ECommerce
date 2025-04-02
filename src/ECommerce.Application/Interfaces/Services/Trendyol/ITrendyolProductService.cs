using ECommerce.Core.Application;
using Trendyol.Client;

namespace ECommerce.Trendyol;

public interface ITrendyolProductService
{
    Task<IDataResult<GetProductsResponseModel>> GetProductsAsync(ProductQueryParametersDTO parameters);
    Task<IDataResult<TrendyolErrorResultDTO>> CreateProductsAsync(List<TrendyolProductDTO> products);
    Task<IDataResult<TrendyolErrorResultDTO>> CreateProductAsync(TrendyolProductDTO product);
    Task<IDataResult<TrendyolErrorResultDTO>> UpdatePriceAndInventoryAsync(List<TrendyolPriceAndInventoryDTO> priceAndInventories);
    Task<IDataResult<TrendyolErrorResultDTO>> DeleteProductAsync(List<string> productBarcodes);
    Task<IDataResult<List<BrandModel>>> GetBrandsAsync();
    Task<IDataResult<List<BrandModel>>> GetBrandsAsync(string search, int size = 100);
    Task<IDataResult<List<CategoryModel>>> GetCategoriesAsync(string search, int size = 100);
    Task<IDataResult<TrendyolErrorResultDTO>> UpdateProductAsync(TrendyolProductDTO product);

}
