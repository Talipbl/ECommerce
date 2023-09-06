using Newtonsoft.Json;

namespace Marketplaces.Trendyol
{
    public class UpdateBoxInfoRequest
    {
        [JsonProperty("boxQuantity")]
        public int BoxQuantity { get; set; }

        [JsonProperty("deci")]
        public double Deci { get; set; }
    }

}
