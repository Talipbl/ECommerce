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
            TrendyolOrderClient crawlerClient = new TrendyolOrderClient();

            OrderQueryParametersModel order = new OrderQueryParametersModel() { Status = "Picking" };

            var result = crawlerClient.GetOrders(order);

            result.Wait();
        }
    }
}