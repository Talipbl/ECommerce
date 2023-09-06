using Newtonsoft.Json;

namespace Marketplaces.Trendyol
{
    public class ImageModel
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
