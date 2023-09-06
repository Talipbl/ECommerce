using Newtonsoft.Json;

namespace ECommerce.Service.ExternalServices.TrendyolClient.Models.ProductModels
{
    public class BrandModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
