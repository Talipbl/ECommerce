using Newtonsoft.Json;

namespace ECommerce.Service.ExternalServices.TrendyolClient.Models.OrderModels
{
    public class FailureToSupplyReuqest
    {
        [JsonProperty("lines")]
        public List<Line> Lines { get; set; }

        [JsonProperty("reasonId")]
        public int ReasonId { get; set; }

        public class Line
        {
            [JsonProperty("lineId")]
            public int LineId { get; set; }

            [JsonProperty("quantity")]
            public int Quantity { get; set; }
        }
    }

}
