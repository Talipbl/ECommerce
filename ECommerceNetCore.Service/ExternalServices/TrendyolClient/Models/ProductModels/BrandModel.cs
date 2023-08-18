using Newtonsoft.Json;

namespace ECommerceNetCore.Service.ExternalServices.TrendyolClient
{
    public class BrandModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
