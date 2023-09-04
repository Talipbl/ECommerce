using Newtonsoft.Json;

namespace ECommerce.Service.ExternalServices.TrendyolClient.Models.OrderModels
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
