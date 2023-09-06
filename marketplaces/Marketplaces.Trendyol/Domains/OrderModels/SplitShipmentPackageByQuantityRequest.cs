using Newtonsoft.Json;

namespace Marketplaces.Trendyol
{
    public class SplitShipmentPackageByQuantityRequest
    {
        [JsonProperty("quantitySplit")]
        public List<QuantitySplitModel> QuantitySplit { get; set; }

        public class QuantitySplitModel
        {
            [JsonProperty("orderLineId")]
            public int OrderLineId { get; set; }

            [JsonProperty("quantities")]
            public List<int> Quantities { get; set; }
        }
    }

}
