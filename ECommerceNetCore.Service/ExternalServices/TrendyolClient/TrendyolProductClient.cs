using ECommerce.Service.ExternalServices.Helpers;
using ECommerce.Service.ExternalServices.TrendyolClient.Models;
using ECommerce.Service.ExternalServices.TrendyolClient.Models.ProductModels;
using ECommerce.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ECommerce.Service.ExternalServices.TrendyolClient
{
    //bkz: https://developers.trendyol.com/docs/category/%C3%BCr%C3%BCn-entegrasyonu

    public class TrendyolProductClient
    {
        string Url = "https://stageapi.trendyol.com"; //https://stageapi.trendyol.com //https://api.trendyol.com
        string Prefix = "/stagesapigw"; // stagesapigw // sapigw
        private TrendyolHttpClient Client { get; set; }
        private string SupplierId { get; set; }
        public TrendyolProductClient(ApiAuthenticationModel authorization)
        {
            SupplierId = authorization.SellerId;
            Client = new TrendyolHttpClient(Url, SupplierId, authorization);
        }
        public async Task<RootResponseModel<List<BrandModel>>> GetBrandsAsync()
        {
            return await Task.Run(() => Client.GetAsync<List<BrandModel>>($"{Prefix}/brands"));
        }
        public async Task<RootResponseModel<List<CategoryModel>>> GetCategoriesAsync()
        {
            return await Task.Run(() => Client.GetAsync<List<CategoryModel>>($"{Prefix}/product-categories"));
        }
        public async Task<RootResponseModel<AttributesModel>> GetCategoryAttributesAsync(int categoryId)
        {
            return await Task.Run(() => Client.GetAsync<AttributesModel>($"{Prefix}/product-categories/{categoryId}/attributes"));
        }
        public async Task<RootResponseModel<GetProductsResponseModel>> GetProductsAsync(ProductQueryParametersModel queries)
        {
            string queryString = JsonHelper.BuildQueryString(queries);
            return await Task.Run(() => Client.GetAsync<GetProductsResponseModel>($"{Prefix}/suppliers/{SupplierId}/products?{queryString}"));
        }
        public async Task<RootResponseModel<ServiceResponseModel>> CreateProductsAsync(ProductRequestModel request)
        {
            return await Task.Run(() => Client.PostAsync<ServiceResponseModel>(request, $"{Prefix}/suppliers/{SupplierId}/v2/products"));
        }
        public async Task<RootResponseModel<ServiceResponseModel>> UpdateProductsAsync(ProductRequestModel request)
        {
            return await Task.Run(() => Client.PutAsync<ServiceResponseModel>(request, $"{Prefix}/suppliers/{SupplierId}/v2/products"));
        }
        public async Task<RootResponseModel<ServiceResponseModel>> DeleteProductsAsync(DeleteProductRequestModel request)
        {
            return await Task.Run(() => Client.DeleteAsync<ServiceResponseModel>(request, $"{Prefix}/suppliers/{SupplierId}/v2/products"));
        }
        public async Task<RootResponseModel<ServiceResponseModel>> UpdatePriceAndInventoryAsync(PriceAndInventoryUpdateRequest request)
        {
            return await Task.Run(() => Client.PostAsync<ServiceResponseModel>(request, $"{Prefix}/suppliers/{SupplierId}/products/price-and-inventory"));
        }
        public async Task<RootResponseModel<BatchRequestResultModel>> GetBatchRequestAsync(string batchRequestId)
        {
            return await Task.Run(() => Client.GetAsync<BatchRequestResultModel>($"{Prefix}/suppliers/{SupplierId}/products/batch-requests/{batchRequestId}"));
        }
        public async Task<RootResponseModel<GetSupplierAddressesResponseModel>> GetSupplierAddressesAsync()
        {
            return await Task.Run(() => Client.GetAsync<GetSupplierAddressesResponseModel>($"{Prefix}/suppliers/{SupplierId}/addresses"));
        }
    }
}
