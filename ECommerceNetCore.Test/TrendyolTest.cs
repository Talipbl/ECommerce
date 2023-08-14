using ECommerceNetCore.Application.DataTransferObjects;
using ECommerceNetCore.Application.Validators;
using ECommerceNetCore.Service.ExternalServices.APIs.TrendyolClient;

namespace ECommerceNetCore.Test
{
    public class TrendyolTest
    {
        [Fact]
        public void Get_Web_Search()
        {
            TrendyolCrawlerClient crawlerClient = new TrendyolCrawlerClient();

            var result = crawlerClient.GetWebSearchResult("https://public.trendyol.com/discovery-web-searchgw-service/v2/api/infinite-scroll/sr?wg=2&bu=100146%2C100283%2C100151%2C100145%2C100147%2C100093%2C100094%2C100095&sst=MOST_FAVOURITE&rc=975%2C407%2C425%2C429%2C411%2C427&pr=3");

            result.Wait();
        }
    }
}