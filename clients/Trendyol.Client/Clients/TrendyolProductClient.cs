namespace Trendyol.Client
{
    /// <summary>
    /// <see cref="https://developers.trendyol.com/docs/category/%C3%BCr%C3%BCn-entegrasyonu"/>
    /// </summary>
    public class TrendyolProductClient
    {
        private BaseHttpClient Client { get; set; }

        readonly string URL = "https://api.trendyol.com";
        readonly string PREFIX = "/sapigw";
        readonly string _supplierId;
        public TrendyolProductClient(ApiAuthentication authentication)
        {
            _supplierId = authentication.SellerId;
            Client = new BaseHttpClient(URL, _supplierId, authentication);
        }
        public async Task<RootResponseModel<BrandListModel>> GetBrandsAsync()
        {
            return await Client.GetAsync<BrandListModel>($"{PREFIX}/brands");
        }
        public async Task<RootResponseModel<List<BrandModel>>> GetBrandsByNameAsync(string name)
        {
            return await Task.Run(() => Client.GetAsync<List<BrandModel>>($"{PREFIX}/brands/by-name?name={name}"));
        }
        public async Task<RootResponseModel<CategoryListModel>> GetCategoriesAsync()
        {
            return await Client.GetAsync<CategoryListModel>($"{PREFIX}/product-categories");
        }
        public async Task<RootResponseModel<AttributesModel>> GetCategoryAttributesAsync(int categoryId)
        {
            return await Client.GetAsync<AttributesModel>($"{PREFIX}/product-categories/{categoryId}/attributes");
        }
        public async Task<RootResponseModel<GetProductsResponseModel>> GetProductsAsync(ProductQueryParametersModel queries)
        {
            string queryString = JsonHelper.BuildQueryString(queries);
            return await Client.GetAsync<GetProductsResponseModel>($"{PREFIX}/suppliers/{_supplierId}/products?{queryString}");
        }
        public async Task<RootResponseModel<ServiceResponseModel>> CreateProductsAsync(ProductRequestModel request)
        {
            return await Client.PostAsync<ServiceResponseModel>(request, $"{PREFIX}/suppliers/{_supplierId}/v2/products");
        }
        public async Task<RootResponseModel<ServiceResponseModel>> UpdateProductsAsync(ProductRequestModel request)
        {
            return await Client.PutAsync<ServiceResponseModel>(request, $"{PREFIX}/suppliers/{_supplierId}/v2/products");
        }
        public async Task<RootResponseModel<ServiceResponseModel>> DeleteProductsAsync(DeleteProductRequestModel request)
        {
            return await Client.DeleteAsync<ServiceResponseModel>(request, $"{PREFIX}/suppliers/{_supplierId}/v2/products");
        }
        public async Task<RootResponseModel<ServiceResponseModel>> UpdatePriceAndInventoryAsync(PriceAndInventoryUpdateRequest request)
        {
            return await Client.PostAsync<ServiceResponseModel>(request, $"{PREFIX}/suppliers/{_supplierId}/products/price-and-inventory");
        }
        public async Task<RootResponseModel<BatchRequestResultModel>> GetBatchRequestAsync(string batchRequestId)
        {
            return await Client.GetAsync<BatchRequestResultModel>($"{PREFIX}/suppliers/{_supplierId}/products/batch-requests/{batchRequestId}");
        }
        public async Task<RootResponseModel<GetSupplierAddressesResponseModel>> GetSupplierAddressesAsync()
        {
            return await Client.GetAsync<GetSupplierAddressesResponseModel>($"{PREFIX}/suppliers/{_supplierId}/addresses");
        }
    }
}
