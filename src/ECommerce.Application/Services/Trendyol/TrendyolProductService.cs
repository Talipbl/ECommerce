using ECommerce.Core.Application;
using ECommerce.Services;
using Trendyol.Client;
using static Trendyol.Client.DeleteProductRequestModel;

namespace ECommerce.Trendyol
{
    public class TrendyolProductService(IMappingService mapper) : ITrendyolProductService
    {
        TrendyolProductClient _productClient = new(ApiAuthentication.CreateAuthentication("atBqHAZm2Eg1ZttXGpMZ", "LSEzaIx17XkuFiYyXyRu", "836049"));

        private readonly IMappingService _mapper = mapper;

        public async Task<IDataResult<TrendyolErrorResultDTO>> CreateProductAsync(TrendyolProductDTO product)
        {
            try
            {
                ProductRequestModel model = _mapper.Map<ProductRequestModel>(new List<TrendyolProductDTO>() { product });
                var result = await _productClient.CreateProductsAsync(model);
                if (result.IsSuccess)
                    return new DataResult<TrendyolErrorResultDTO>(result.IsSuccess, result.OkResponse.BatchRequestId);

                var errorReturn = _mapper.Map<TrendyolErrorResultDTO>(result.ErrorValueReturn);
                return new DataResult<TrendyolErrorResultDTO>(errorReturn, result.IsSuccess);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IDataResult<TrendyolErrorResultDTO>> CreateProductsAsync(List<TrendyolProductDTO> products)
        {
            try
            {
                ProductRequestModel model = _mapper.Map<ProductRequestModel>(products);
                var result = await _productClient.CreateProductsAsync(model);
                if (result.IsSuccess)
                    return new DataResult<TrendyolErrorResultDTO>(result.IsSuccess, result.OkResponse.BatchRequestId);

                var errorReturn = _mapper.Map<TrendyolErrorResultDTO>(result.ErrorValueReturn);
                return new DataResult<TrendyolErrorResultDTO>(errorReturn, result.IsSuccess);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IDataResult<TrendyolErrorResultDTO>> DeleteProductAsync(List<string> productBarcodes)
        {
            DeleteProductRequestModel model = _mapper.Map<DeleteProductRequestModel>(productBarcodes);
            var result = await _productClient.DeleteProductsAsync(model);

            if (result.IsSuccess)
                return new DataResult<TrendyolErrorResultDTO>(result.IsSuccess, result.OkResponse.BatchRequestId);

            var errorReturn = _mapper.Map<TrendyolErrorResultDTO>(result.ErrorValueReturn);
            return new DataResult<TrendyolErrorResultDTO>(errorReturn, result.IsSuccess);
        }

        [CacheAspect(Duration = 300)]
        public async Task<IDataResult<List<BrandModel>>> GetBrandsAsync()
        {
            var result = await _productClient.GetBrandsAsync();
            return new DataResult<List<BrandModel>>(result.OkResponse.Brands, true);
        }

        [CacheAspect(Duration = 500)]
        public async Task<IDataResult<List<BrandModel>>> GetBrandsAsync(string search, int size = 100)
        {
            var result = await _productClient.GetBrandsByNameAsync(search);
            if (result != null && result.OkResponse.Count > 0)
            {
                result.OkResponse = result.OkResponse.Where(s => s.Name.Contains(search, StringComparison.OrdinalIgnoreCase)).Take(size).ToList();
                return new DataResult<List<BrandModel>>(result.OkResponse, true);
            }
            return new DataResult<List<BrandModel>>(false, "Brands not found!");
        }
        [CacheAspect(Duration = 300)]
        public async Task<IDataResult<List<CategoryModel>>> GetCategoriesAsync(string search, int size = 100)
        {
            //TO-DO: Kategori filtrelemesi yapılacak!
            var result = await _productClient.GetCategoriesAsync();
            if (result != null && result.OkResponse.Categories.Count > 0)
            {
                return new DataResult<List<CategoryModel>>(result.OkResponse.Categories, true);
            }
            return new DataResult<List<CategoryModel>>(false, "Categories not found!");
        }
        [LogAspect]
        public async Task<IDataResult<GetProductsResponseModel>> GetProductsAsync(ProductQueryParametersDTO parameters)
        {
            ProductQueryParametersModel model = _mapper.Map<ProductQueryParametersModel>(parameters);
            var result = await _productClient.GetProductsAsync(model);

            return new DataResult<GetProductsResponseModel>(result.OkResponse, result.IsSuccess);
        }

        public async Task<IDataResult<TrendyolErrorResultDTO>> UpdatePriceAndInventoryAsync(List<TrendyolPriceAndInventoryDTO> priceAndInventories)
        {
            PriceAndInventoryUpdateRequest model = _mapper.Map<PriceAndInventoryUpdateRequest>(priceAndInventories);
            var result = await _productClient.UpdatePriceAndInventoryAsync(model);

            if (result.IsSuccess)
                return new DataResult<TrendyolErrorResultDTO>(result.IsSuccess, result.OkResponse.BatchRequestId);

            var errorReturn = _mapper.Map<TrendyolErrorResultDTO>(result.ErrorValueReturn);
            return new DataResult<TrendyolErrorResultDTO>(errorReturn, result.IsSuccess);
        }
    }
}
