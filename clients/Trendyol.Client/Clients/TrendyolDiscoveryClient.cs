namespace Trendyol.Client
{
    /// <summary>
    /// Trendyol arama ve listeleme servisi.
    /// </summary>
    public class TrendyolDiscoveryClient
    {
        readonly string URL = "https://apigw.trendyol.com/";
        private BaseHttpClient Client { get; set; }
        public TrendyolDiscoveryClient()
        {
            Client = new BaseHttpClient(URL);
        }
        public async Task<RootResponseModel<WebSearchResultModel>> GetWebSearchResult(string searchUri, int page = 1)
        {
            string pageQuery = string.Empty;
            if (!searchUri.Contains('?'))
                pageQuery = $"?pi={page}";
            else
                pageQuery = $"&pi={page}";

            return await Client.GetAsync<WebSearchResultModel>($"/discovery-web-searchgw-service/v2/api/infinite-scroll/{searchUri}{pageQuery}");
        }

        public async Task<RootResponseModel<CrawlerProductDetailModel>> GetProductDetail(int productId)
        {
            return await Client.GetAsync<CrawlerProductDetailModel>($"/discovery-web-productgw-service/api/productDetail/{productId}");
        }
    }
}
