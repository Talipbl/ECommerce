using Newtonsoft.Json;

namespace Trendyol.Client
{
    public class BrandModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class BrandListModel
    {
        [JsonProperty("brands")]
        public List<BrandModel> Brands { get; set; }
    }
}
