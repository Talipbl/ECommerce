using ECommerceNetCore.Application.Aspects;
using ECommerceNetCore.Service.ExternalServices.APIs.TrendyolClient.Models;
using ECommerceNetCore.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ECommerceNetCore.Service.ExternalServices.APIs.TrendyolClient
{
    [SecurityProtocolAspect(ProtocolType = SecurityProtocolType.Tls12)]
    public class TrendyolApiClient
    {
        private TrendyolHttpClient Client { get; set; }
        private string SupplierId { get; set; } = "836049";
        public TrendyolApiClient()
        {
            //TO-DO: Buradaki bilgiler veri tabanına kaydedilip oradan çekilecek.
            string auth = Convert.ToBase64String(Encoding.ASCII.GetBytes("mhnqkT7WsnoMmpca49NY:yYxBaDjJw1QaRykToWHt"));

            ApiAuthorizationModel authorization = new ApiAuthorizationModel()
            {
                ApiKey = "mhnqkT7WsnoMmpca49NY",
                ApiSecretKey = "yYxBaDjJw1QaRykToWHt",
                Authorization = $"Basic {auth}"
            };

            Client = new TrendyolHttpClient("https://api.trendyol.com/sapigw", SupplierId, authorization);
        }
        public async Task<HttpResponseModel<List<BrandModel>>> GetBrands()
        {
            return await Task.Run(() => Client.GetAsync<List<BrandModel>>("/brands"));
        }
        public async Task<HttpResponseModel<List<CategoryModel>>> GetCategories()
        {
            return await Task.Run(() => Client.GetAsync<List<CategoryModel>>("/product-categories"));
        }
        public async Task<HttpResponseModel<AttributesModel>> GetCategoryAttributes(int categoryId)
        {
            return await Task.Run(() => Client.GetAsync<AttributesModel>($"/product-categories/{categoryId}/attributes"));
        }
        public async Task<HttpResponseModel<GetProductsResponseModel>> GetProducts(ProductQueryParametersModel queries)
        {
            string queryString = JsonHelper.BuildQueryString(queries);
            return await Task.Run(() => Client.GetAsync<GetProductsResponseModel>($"/suppliers/{SupplierId}/v2/products?{queryString}"));
        }
        public async Task<HttpResponseModel<ProductModel>> CreateProducts(List<ProductModel> productsModel)
        {
            return await Task.Run(() => Client.PostAsync<ProductModel>(productsModel, $"/suppliers/{SupplierId}/v2/products"));
        }
        public async Task<HttpResponseModel<ProductModel>> UpdateProducts(List<ProductModel> productsModel)
        {
            return await Task.Run(() => Client.PutAsync<ProductModel>(productsModel, $"/suppliers/{SupplierId}/v2/products"));
        }
        public async Task<HttpResponseModel<ServiceResponseModel>> DeleteProducts(List<DeleteProductModel> deleteProducts)
        {
            return await Task.Run(() => Client.DeleteAsync<ServiceResponseModel>(deleteProducts, $"/suppliers/{SupplierId}/v2/products"));
        }
        public async Task<HttpResponseModel<ServiceResponseModel>> UpdatePriceAndInventory(List<PriceAndInventoryUpdateModel> pricesAndInventories)
        {
            return await Task.Run(() => Client.PostAsync<ServiceResponseModel>(pricesAndInventories, $"/suppliers/{SupplierId}/products/price-and-inventory"));
        }
        public async Task<HttpResponseModel<BatchRequestResultModel>> GetBatchRequest(int batchRequestId)
        {
            return await Task.Run(() => Client.GetAsync<BatchRequestResultModel>($"/suppliers/{SupplierId}/products/batch-requests/{batchRequestId}"));
        }
    }
}
