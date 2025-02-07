using ECommerce.Core.Application;
using Trendyol.Client;

namespace ECommerce.Trendyol;

public interface ITrendyolProductService
{
    Task<IDataResult<GetProductsResponseModel>> GetProductsAsync(ProductQueryParametersDto parameters);
    Task<IDataResult<TrendyolErrorResultDto>> CreateProductsAsync(List<TrendyolProductDto> products);
    Task<IDataResult<TrendyolErrorResultDto>> CreateProductAsync(TrendyolProductDto product);
    Task<IDataResult<TrendyolErrorResultDto>> UpdatePriceAndInventoryAsync(List<TrendyolPriceAndInventoryDto> priceAndInventories);
    Task<IDataResult<TrendyolErrorResultDto>> DeleteProductAsync(List<string> productBarcodes);
    Task<IDataResult<List<BrandModel>>> GetBrandsAsync();
    Task<IDataResult<List<BrandModel>>> GetBrandsAsync(string search, int size = 100);
    Task<IDataResult<List<CategoryModel>>> GetCategoriesAsync(string search, int size = 100);

}
