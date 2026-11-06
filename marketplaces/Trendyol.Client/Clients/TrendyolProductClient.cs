using Microsoft.Extensions.Options;

namespace Trendyol.Client
{
    /// <summary>
    /// <see cref="https://developers.trendyol.com/docs/category/%C3%BCr%C3%BCn-entegrasyonu"/>
    /// </summary>
    public class TrendyolProductClient
    {
        private readonly BaseHttpClient _client;

        readonly string Prefix = "/sapigw";
        readonly string _supplierId;
        public TrendyolProductClient(HttpClient httpClient, IOptions<TrendyolOptions> options)
        {
            _supplierId = options.Value.SellerId;
            _client = new BaseHttpClient(httpClient);
        }
        public async Task<RootResponseModel<BrandListModel>> GetBrandsAsync()
        {
            return await _client.GetAsync<BrandListModel>($"{Prefix}/brands");
        }
        public async Task<RootResponseModel<List<BrandModel>>> GetBrandsByNameAsync(string name)
        {
            return await Task.Run(() => _client.GetAsync<List<BrandModel>>($"{Prefix}/brands/by-name?name={name}"));
        }
        public async Task<RootResponseModel<CategoryListModel>> GetCategoriesAsync()
        {
            return await _client.GetAsync<CategoryListModel>($"{Prefix}/product-categories");
        }
        public async Task<RootResponseModel<AttributesModel>> GetCategoryAttributesAsync(int categoryId)
        {
            return await _client.GetAsync<AttributesModel>($"{Prefix}/product-categories/{categoryId}/attributes");
        }
        public async Task<RootResponseModel<GetProductsResponseModel>> GetProductsAsync(ProductQueryParametersModel queries)
        {
            string queryString = JsonHelper.BuildQueryString(queries);
            return await _client.GetAsync<GetProductsResponseModel>($"{Prefix}/suppliers/{_supplierId}/products?{queryString}");
        }
        public async Task<RootResponseModel<ServiceResponseModel>> CreateProductsAsync(ProductRequestModel request)
        {
            return await _client.PostAsync<ServiceResponseModel>(request, $"{Prefix}/suppliers/{_supplierId}/v2/products");
        }
        public async Task<RootResponseModel<ServiceResponseModel>> UpdateProductsAsync(ProductRequestModel request)
        {
            return await _client.PutAsync<ServiceResponseModel>(request, $"{Prefix}/suppliers/{_supplierId}/v2/products");
        }
        public async Task<RootResponseModel<ServiceResponseModel>> DeleteProductsAsync(DeleteProductRequestModel request)
        {
            return await _client.DeleteAsync<ServiceResponseModel>(request, $"{Prefix}/suppliers/{_supplierId}/v2/products");
        }
        public async Task<RootResponseModel<ServiceResponseModel>> UpdatePriceAndInventoryAsync(PriceAndInventoryUpdateRequest request)
        {
            return await _client.PostAsync<ServiceResponseModel>(request, $"{Prefix}/suppliers/{_supplierId}/products/price-and-inventory");
        }
        public async Task<RootResponseModel<BatchRequestResultModel>> GetBatchRequestAsync(string batchRequestId)
        {
            return await _client.GetAsync<BatchRequestResultModel>($"{Prefix}/suppliers/{_supplierId}/products/batch-requests/{batchRequestId}");
        }
        public async Task<RootResponseModel<GetSupplierAddressesResponseModel>> GetSupplierAddressesAsync()
        {
            return await _client.GetAsync<GetSupplierAddressesResponseModel>($"{Prefix}/suppliers/{_supplierId}/addresses");
        }
    }
}
