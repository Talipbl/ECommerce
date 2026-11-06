using Newtonsoft.Json;

namespace N11.Client
{
    public class UpdateOrderRequest
    {
        [JsonProperty("lines")]
        public List<Line> Lines { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        public class Line
        {
            [JsonProperty("lineId")]
            public int LineId { get; set; }
        }
    }
}
