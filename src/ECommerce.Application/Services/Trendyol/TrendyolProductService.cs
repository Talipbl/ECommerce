using ECommerce.Core.Application;
using ECommerce.Services;
using Trendyol.Client;

namespace ECommerce.Trendyol
{
    public class TrendyolProductService(ITrendyolProductAdapter _adapter) : ITrendyolProductService
    {
        TrendyolProductClient _productClient = new(ApiAuthentication.CreateAuthentication("atBqHAZm2Eg1ZttXGpMZ", "LSEzaIx17XkuFiYyXyRu", "836049"));

        [LogAspect]
        public async Task<IDataResult<TrendyolErrorResultDTO>> CreateProductAsync(ProductRequestDTO product)
        {
            ProductRequestModel model = _adapter.AdaptProductsRequest([product]);
            var result = await _productClient.CreateProductsAsync(model);
            if (result.IsSuccess)
                return new DataResult<TrendyolErrorResultDTO>(result.IsSuccess, result.OkResponse.BatchRequestId);

            var errorReturn = _adapter.AdaptErrorResult(result.ErrorValueReturn);
            return new DataResult<TrendyolErrorResultDTO>(errorReturn, result.IsSuccess);
        }

        [LogAspect]
        public async Task<IDataResult<TrendyolErrorResultDTO>> CreateProductsAsync(List<ProductRequestDTO> products)
        {
            ProductRequestModel model = _adapter.AdaptProductsRequest(products);
            var result = await _productClient.CreateProductsAsync(model);
            if (result.IsSuccess)
                return new DataResult<TrendyolErrorResultDTO>(result.IsSuccess, result.OkResponse.BatchRequestId);

            var errorReturn = _adapter.AdaptErrorResult(result.ErrorValueReturn);
            return new DataResult<TrendyolErrorResultDTO>(errorReturn, result.IsSuccess);
        }

        public async Task<IDataResult<TrendyolErrorResultDTO>> DeleteProductAsync(List<string> productBarcodes)
        {
            DeleteProductRequestModel model = _adapter.Adapt<DeleteProductRequestModel>(productBarcodes);
            var result = await _productClient.DeleteProductsAsync(model);

            if (result.IsSuccess)
                return new DataResult<TrendyolErrorResultDTO>(result.IsSuccess, result.OkResponse.BatchRequestId);

            var errorReturn = _adapter.AdaptErrorResult(result.ErrorValueReturn);
            return new DataResult<TrendyolErrorResultDTO>(errorReturn, result.IsSuccess);
        }

        [CacheAspect(Duration = 300)]
        public async Task<IDataResult<List<BrandResponseDTO>>> GetBrandsAsync()
        {
            var result = await _productClient.GetBrandsAsync();
            var dto = _adapter.Adapt<List<BrandResponseDTO>>(result.OkResponse.Brands);

            return new DataResult<List<BrandResponseDTO>>(dto, true);
        }

        [CacheAspect(Duration = 500)]
        public async Task<IDataResult<List<BrandResponseDTO>>> GetBrandsAsync(string search, int size = 100)
        {
            var result = await _productClient.GetBrandsByNameAsync(search);
            if (result != null && result.OkResponse.Count > 0)
            {
                result.OkResponse = result.OkResponse.Where(s => s.Name.Contains(search, StringComparison.OrdinalIgnoreCase)).Take(size).ToList();
                var dto = _adapter.Adapt<List<BrandResponseDTO>>(result.OkResponse);

                return new DataResult<List<BrandResponseDTO>>(dto, true);
            }
            return new DataResult<List<BrandResponseDTO>>(false, "Brands not found!");
        }

        [CacheAspect(Duration = 300)]
        public async Task<IDataResult<List<CategoryResponseDTO>>> GetCategoriesAsync(string search, int size = 100)
        {
            var result = await _productClient.GetCategoriesAsync();
            if (result != null && result.OkResponse.Categories.Count > 0)
            {
                var dto = _adapter.Adapt<List<CategoryResponseDTO>>(result.OkResponse.Categories);
                return new DataResult<List<CategoryResponseDTO>>(FindMatchingCategories(dto, search), true);
            }
            return new DataResult<List<CategoryResponseDTO>>(false, "Categories not found!");
        }

        [LogAspect]
        public async Task<IDataResult<ProductsResponseDTO>> GetProductsAsync(ProductQueryParametersDTO parameters)
        {
            ProductQueryParametersModel model = _adapter.Adapt<ProductQueryParametersModel>(parameters);
            var result = await _productClient.GetProductsAsync(model);
            var dto = _adapter.Adapt<ProductsResponseDTO>(result.OkResponse);

            return new DataResult<ProductsResponseDTO>(dto, result.IsSuccess);
        }

        public async Task<IDataResult<TrendyolErrorResultDTO>> UpdatePriceAndInventoryAsync(List<PriceAndInventoryUpdateRequestDTO> priceAndInventories)
        {
            PriceAndInventoryUpdateRequest model = _adapter.AdaptPriceAndInventoryRequest(priceAndInventories);
            var result = await _productClient.UpdatePriceAndInventoryAsync(model);

            if (result.IsSuccess)
                return new DataResult<TrendyolErrorResultDTO>(result.IsSuccess, result.OkResponse.BatchRequestId);

            var errorReturn = _adapter.AdaptErrorResult(result.ErrorValueReturn);
            return new DataResult<TrendyolErrorResultDTO>(errorReturn, result.IsSuccess);
        }

        public async Task<IDataResult<TrendyolErrorResultDTO>> UpdateProductAsync(ProductRequestDTO product)
        {
            ProductRequestModel model = _adapter.AdaptProductsRequest([product]);
            var result = await _productClient.UpdateProductsAsync(model);

            if (result.IsSuccess)
                return new DataResult<TrendyolErrorResultDTO>(result.IsSuccess, result.OkResponse.BatchRequestId);

            var errorReturn = _adapter.AdaptErrorResult(result.ErrorValueReturn);
            return new DataResult<TrendyolErrorResultDTO>(errorReturn, result.IsSuccess);
        }


        private List<CategoryResponseDTO> FindMatchingCategories(List<CategoryResponseDTO> categories, string search)
        {
            var matchingCategories = new List<CategoryResponseDTO>();

            foreach (var category in categories)
            {
                var matchingSubCategories = FindMatchingCategoriesInSubCategories(category.SubCategories, search);
                if (matchingSubCategories != null && matchingSubCategories.Any())
                {
                    matchingCategories.AddRange(matchingSubCategories);
                }
            }

            return matchingCategories;

            List<CategoryResponseDTO> FindMatchingCategoriesInSubCategories(List<CategoryResponseDTO> subCategories, string search)
            {
                var matchingCategories = new List<CategoryResponseDTO>();

                if (subCategories == null || !subCategories.Any())
                    return matchingCategories;

                foreach (var subCategory in subCategories)
                {
                    if (subCategory.Name.ToLower().Contains(search))
                    {
                        matchingCategories.Add(subCategory);
                    }

                    var matchingSubCategory = FindMatchingCategoriesInSubCategories(subCategory.SubCategories, search);
                    if (matchingSubCategory != null && matchingSubCategory.Any())
                    {
                        matchingCategories.AddRange(matchingSubCategory);
                    }
                }

                return matchingCategories;
            }
        }
    }
}
