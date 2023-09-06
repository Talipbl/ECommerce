using Newtonsoft.Json;

namespace Trendyol.Client
{
    public class ImageModel
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
