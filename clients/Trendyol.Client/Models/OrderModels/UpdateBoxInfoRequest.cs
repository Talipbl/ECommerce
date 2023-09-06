using Newtonsoft.Json;

namespace Trendyol.Client
{
    public class UpdateBoxInfoRequest
    {
        [JsonProperty("boxQuantity")]
        public int BoxQuantity { get; set; }

        [JsonProperty("deci")]
        public double Deci { get; set; }
    }

}
