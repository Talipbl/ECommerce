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
            
            TrendyolClaimReturnClient crawlerClient = new TrendyolClaimReturnClient();

            //OrderQueryParametersModel order = new OrderQueryParametersModel() { Status = "Picking" };

            var result = crawlerClient.GetClaimsIssueReasons("bd1e6312 - 4aae - 4763 - 9280 - fb75da2679c3");

            result.Wait();
        }
    }
}