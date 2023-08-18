using Newtonsoft.Json;

namespace ECommerceNetCore.Service.ExternalServices.TrendyolClient
{
    public class UpdateBoxInfoRequest
    {
        [JsonProperty("boxQuantity")]
        public int BoxQuantity { get; set; }

        [JsonProperty("deci")]
        public double Deci { get; set; }
    }

}
