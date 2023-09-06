using Newtonsoft.Json;

namespace ECommerce.Service.ExternalServices.TrendyolClient.Models.OrderModels
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
