using Newtonsoft.Json;

namespace ECommerceNetCore.Service.ExternalServices.TrendyolClient
{
    public class ImageModel
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
