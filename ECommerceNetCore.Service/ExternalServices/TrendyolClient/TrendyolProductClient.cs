using ECommerceNetCore.Application.Aspects;
using ECommerceNetCore.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ECommerceNetCore.Service.ExternalServices.TrendyolClient
{
    //bkz: https://developers.trendyol.com/docs/category/%C3%BCr%C3%BCn-entegrasyonu

    [SecurityProtocolAspect(ProtocolType = SecurityProtocolType.Tls12)]
    public class TrendyolProductClient
    {
        private TrendyolHttpClient Client { get; set; }
        private string SupplierId { get; set; } = "836049";
        public TrendyolProductClient()
        {
            //TO-DO: Buradaki bilgiler veri tabanına kaydedilip oradan çekilecek.
            string auth = Convert.ToBase64String(Encoding.ASCII.GetBytes("mhnqkT7WsnoMmpca49NY:yYxBaDjJw1QaRykToWHt"));

            ApiAuthorizationModel authorization = new ApiAuthorizationModel()
            {
                ApiKey = "mhnqkT7WsnoMmpca49NY",
                ApiSecretKey = "yYxBaDjJw1QaRykToWHt",
                Authorization = $"Basic {auth}"
            };

            Client = new TrendyolHttpClient("https://api.trendyol.com", SupplierId, authorization);
        }
        public async Task<HttpResponseModel<List<BrandModel>>> GetBrands()
        {
            return await Task.Run(() => Client.GetAsync<List<BrandModel>>("/sapigw/brands"));
        }
        public async Task<HttpResponseModel<List<CategoryModel>>> GetCategories()
        {
            return await Task.Run(() => Client.GetAsync<List<CategoryModel>>("/sapigw/product-categories"));
        }
        public async Task<HttpResponseModel<AttributesModel>> GetCategoryAttributes(int categoryId)
        {
            return await Task.Run(() => Client.GetAsync<AttributesModel>($"/sapigw/product-categories/{categoryId}/attributes"));
        }
        public async Task<HttpResponseModel<GetProductsResponseModel>> GetProducts(ProductQueryParametersModel queries)
        {
            string queryString = JsonHelper.BuildQueryString(queries);
            return await Task.Run(() => Client.GetAsync<GetProductsResponseModel>($"/sapigw/suppliers/{SupplierId}/v2/products?{queryString}"));
        }
        public async Task<HttpResponseModel<ProductRequestModel>> CreateProducts(ProductRequestModel request)
        {
            return await Task.Run(() => Client.PostAsync<ProductRequestModel>(request, $"/sapigw/suppliers/{SupplierId}/v2/products"));
        }
        public async Task<HttpResponseModel<ProductRequestModel>> UpdateProducts(ProductRequestModel request)
        {
            return await Task.Run(() => Client.PutAsync<ProductRequestModel>(request, $"/sapigw/suppliers/{SupplierId}/v2/products"));
        }
        public async Task<HttpResponseModel<ServiceResponseModel>> DeleteProducts(DeleteProductRequestModel request)
        {
            return await Task.Run(() => Client.DeleteAsync<ServiceResponseModel>(request, $"/sapigw/suppliers/{SupplierId}/v2/products"));
        }
        public async Task<HttpResponseModel<ServiceResponseModel>> UpdatePriceAndInventory(PriceAndInventoryUpdateRequest request)
        {
            return await Task.Run(() => Client.PostAsync<ServiceResponseModel>(request, $"/sapigw/suppliers/{SupplierId}/products/price-and-inventory"));
        }
        public async Task<HttpResponseModel<BatchRequestResultModel>> GetBatchRequest(int batchRequestId)
        {
            return await Task.Run(() => Client.GetAsync<BatchRequestResultModel>($"/sapigw/suppliers/{SupplierId}/products/batch-requests/{batchRequestId}"));
        }
    }
}
