using Newtonsoft.Json;

namespace ECommerce.Service.ExternalServices.TrendyolClient.Models.ClaimReturnModels
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
