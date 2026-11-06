using Newtonsoft.Json;

namespace N11.Client
{
    public class UpdateOrderResponse
    {
        [JsonProperty("content")]
        public List<Response> Content { get; set; }

        public class Response
        {
            [JsonProperty("lineId")]
            public int LineId { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("reasons")]
            public string Reasons { get; set; }
        }
    }
}
