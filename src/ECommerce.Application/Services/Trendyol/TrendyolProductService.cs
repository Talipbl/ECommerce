using ECommerce.Core.Application;
using Microsoft.Extensions.Caching.Memory;
using Trendyol.Client;

namespace ECommerce.Trendyol
{
    public class TrendyolProductService(
        ITrendyolProductAdapter adapter,
        TrendyolProductClient productClient,
        IMemoryCache cache) : ITrendyolProductService
    {
        private static readonly TimeSpan ReferenceDataCacheDuration = TimeSpan.FromMinutes(5);

        public Task<IDataResult<TrendyolErrorResultDTO>> CreateProductAsync(ProductRequestDTO product) =>
            CreateProductsAsync([product]);

        public async Task<IDataResult<TrendyolErrorResultDTO>> CreateProductsAsync(List<ProductRequestDTO> products)
        {
            var result = await productClient.CreateProductsAsync(adapter.AdaptProductsRequest(products));
            return ToBatchResult(result);
        }

        public async Task<IDataResult<TrendyolErrorResultDTO>> UpdateProductAsync(ProductRequestDTO product)
        {
            var result = await productClient.UpdateProductsAsync(adapter.AdaptProductsRequest([product]));
            return ToBatchResult(result);
        }

        public async Task<IDataResult<TrendyolErrorResultDTO>> DeleteProductAsync(List<string> productBarcodes)
        {
            var result = await productClient.DeleteProductsAsync(adapter.Adapt<DeleteProductRequestModel>(productBarcodes));
            return ToBatchResult(result);
        }

        public async Task<IDataResult<TrendyolErrorResultDTO>> UpdatePriceAndInventoryAsync(List<PriceAndInventoryUpdateRequestDTO> priceAndInventories)
        {
            var result = await productClient.UpdatePriceAndInventoryAsync(adapter.AdaptPriceAndInventoryRequest(priceAndInventories));
            return ToBatchResult(result);
        }

        public async Task<IDataResult<ProductsResponseDTO>> GetProductsAsync(ProductQueryParametersDTO parameters)
        {
            var result = await productClient.GetProductsAsync(adapter.Adapt<ProductQueryParametersModel>(parameters));
            var dto = adapter.Adapt<ProductsResponseDTO>(result.OkResponse);
            return new DataResult<ProductsResponseDTO>(dto, result.IsSuccess);
        }

        public async Task<IDataResult<List<BrandResponseDTO>>> GetBrandsAsync()
        {
            var brands = await cache.GetOrCreateAsync("trendyol:brands", async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = ReferenceDataCacheDuration;
                var result = await productClient.GetBrandsAsync();
                return adapter.Adapt<List<BrandResponseDTO>>(result.OkResponse.Brands);
            });

            return new DataResult<List<BrandResponseDTO>>(brands!, true);
        }

        public async Task<IDataResult<List<BrandResponseDTO>>> GetBrandsAsync(string search, int size = 100)
        {
            var brands = await cache.GetOrCreateAsync($"trendyol:brands:{search.ToLowerInvariant()}", async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = ReferenceDataCacheDuration;
                var result = await productClient.GetBrandsByNameAsync(search);
                return result.IsSuccess ? result.OkResponse : [];
            });

            var matches = brands!
                .Where(s => s.Name.Contains(search, StringComparison.OrdinalIgnoreCase))
                .Take(size)
                .ToList();

            return matches.Count > 0
                ? new DataResult<List<BrandResponseDTO>>(adapter.Adapt<List<BrandResponseDTO>>(matches), true)
                : new DataResult<List<BrandResponseDTO>>(false, "Brands not found!");
        }

        public async Task<IDataResult<List<CategoryResponseDTO>>> GetCategoriesAsync(string search, int size = 100)
        {
            var categories = await cache.GetOrCreateAsync("trendyol:categories", async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = ReferenceDataCacheDuration;
                var result = await productClient.GetCategoriesAsync();
                return result.IsSuccess ? adapter.Adapt<List<CategoryResponseDTO>>(result.OkResponse.Categories) : [];
            });

            var matches = FindMatchingCategories(categories!, search).Take(size).ToList();

            return matches.Count > 0
                ? new DataResult<List<CategoryResponseDTO>>(matches, true)
                : new DataResult<List<CategoryResponseDTO>>(false, "Categories not found!");
        }

        private IDataResult<TrendyolErrorResultDTO> ToBatchResult(RootResponseModel<ServiceResponseModel> result)
        {
            if (result.IsSuccess)
                return new DataResult<TrendyolErrorResultDTO>(result.IsSuccess, result.OkResponse.BatchRequestId);

            var error = TrendyolErrorParser.Parse(result.ErrorValueReturn);
            return new DataResult<TrendyolErrorResultDTO>(adapter.Adapt<TrendyolErrorResultDTO>(error), result.IsSuccess);
        }

        private static IEnumerable<CategoryResponseDTO> FindMatchingCategories(IEnumerable<CategoryResponseDTO>? categories, string search)
        {
            foreach (var category in categories ?? [])
            {
                if (category.ParentId is not null && category.Name.Contains(search, StringComparison.OrdinalIgnoreCase))
                    yield return category;

                foreach (var match in FindMatchingCategories(category.SubCategories, search))
                    yield return match;
            }
        }
    }
}
