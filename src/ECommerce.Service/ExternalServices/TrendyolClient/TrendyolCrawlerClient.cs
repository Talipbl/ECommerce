using System.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ECommerce.Service.ExternalServices.TrendyolClient.Models;
using ECommerce.Service.Models;

namespace ECommerce.Service.ExternalServices.TrendyolClient
{
    public class TrendyolCrawlerClient
    {
        private TrendyolHttpClient Client { get; set; }
        public TrendyolCrawlerClient()
        {
            Client = new TrendyolHttpClient("https://public.trendyol.com/discovery-web-searchgw-service/v2/api/infinite-scroll/sr?");
        }
        public async Task<RootResponseModel<WebSearchResultModel>> GetWebSearchResult(string searchUri)
        {
            return await Task.Run(() => Client.GetAsync<WebSearchResultModel>(searchUri));
        }
    }
}
