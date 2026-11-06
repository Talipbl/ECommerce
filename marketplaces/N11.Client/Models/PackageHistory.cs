using Newtonsoft.Json;

namespace N11.Client
{
    public class PackageHistory
    {
        [JsonProperty("createdDate")]
        public object CreatedDate { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
