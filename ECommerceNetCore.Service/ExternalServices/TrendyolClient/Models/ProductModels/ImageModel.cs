using Newtonsoft.Json;

namespace ECommerce.Service.ExternalServices.TrendyolClient.Models.ProductModels
{
    public class ImageModel
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
