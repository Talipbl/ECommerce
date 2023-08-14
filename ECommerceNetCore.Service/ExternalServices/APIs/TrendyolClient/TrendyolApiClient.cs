using ECommerceNetCore.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceNetCore.Service.ExternalServices.APIs.TrendyolClient
{
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
        public async Task<HttpResponseModel<CreateProductModel>> CreateProduct(CreateProductModel createProduct)
        {
            return await Task.Run(() => Client.PostAsync<CreateProductModel>(createProduct, $"/suppliers/{SupplierId}/v2/products"));
        }
    }
}
