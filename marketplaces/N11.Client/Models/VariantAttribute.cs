using Newtonsoft.Json;

namespace N11.Client
{
    public class VariantAttribute
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }


}
