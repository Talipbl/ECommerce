using System.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trendyol.Client
{
    public class TrendyolCrawlerClient
    {
        private BaseHttpClient Client { get; set; }
        public TrendyolCrawlerClient()
        {
            Client = new BaseHttpClient("https://public.trendyol.com");
        }
        public async Task<RootResponseModel<WebSearchResultModel>> GetWebSearchResult(string searchUri, int page = 1)
        {
            string pageQuery = string.Empty;
            if (!searchUri.Contains("?"))
                pageQuery = $"?pi={page}";
            else
                pageQuery = $"&pi={page}";

            return await Task.Run(() => Client.GetAsync<WebSearchResultModel>($"/discovery-web-searchgw-service/v2/api/infinite-scroll/{searchUri}{pageQuery}"));
        }

        public async Task<RootResponseModel<CrawlerProductDetailModel>> GetProductDetail(int productId)
        {
            return await Task.Run(() => Client.GetAsync<CrawlerProductDetailModel>($"/discovery-web-productgw-service/api/productDetail/{productId}"));
        }
    }
}
