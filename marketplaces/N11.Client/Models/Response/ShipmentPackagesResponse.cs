using Newtonsoft.Json;

namespace N11.Client
{
    public class ShipmentPackagesResponse
    {
        [JsonProperty("pageCount")]
        public int PageCount { get; set; }

        [JsonProperty("totalPages")]
        public int TotalPages { get; set; }

        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("size")]
        public int Size { get; set; }

        [JsonProperty("content")]
        public List<Order> Orders { get; set; }
    }
}
