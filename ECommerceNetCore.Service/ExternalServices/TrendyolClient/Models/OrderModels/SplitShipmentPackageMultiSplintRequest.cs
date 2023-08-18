using Newtonsoft.Json;

namespace ECommerceNetCore.Service.ExternalServices.TrendyolClient
{
    public class SplitShipmentPackageMultiSplintRequest
    {
        [JsonProperty("splitGroups")]
        public List<SplitGroup> SplitGroups { get; set; }

        public class SplitGroup
        {
            [JsonProperty("orderLineIds")]
            public List<int> OrderLineIds { get; set; }
        }
    }

}
