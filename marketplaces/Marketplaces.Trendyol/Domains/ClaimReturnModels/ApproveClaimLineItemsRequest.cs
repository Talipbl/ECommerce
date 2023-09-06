using Newtonsoft.Json;

namespace Marketplaces.Trendyol
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
