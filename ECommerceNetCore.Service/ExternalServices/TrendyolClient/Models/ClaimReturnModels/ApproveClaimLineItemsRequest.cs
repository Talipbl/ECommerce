using Newtonsoft.Json;

namespace ECommerceNetCore.Service.ExternalServices.TrendyolClient
{
    public class ApproveClaimLineItemsRequest
    {
        [JsonProperty("claimLineItemIdList")]
        public List<string> ClaimLineItemIdList { get; set; }

        [JsonProperty("params")]
        public ParamsModel Params { get; set; }

        public class ParamsModel
        {

        }
    }
}
