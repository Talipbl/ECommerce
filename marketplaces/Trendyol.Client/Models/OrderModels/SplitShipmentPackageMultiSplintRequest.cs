using Newtonsoft.Json;

namespace Trendyol.Client
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
