using Newtonsoft.Json;

namespace ECommerce.Service.ExternalServices.TrendyolClient.Models.OrderModels
{
    public class UpdateBoxInfoRequest
    {
        [JsonProperty("boxQuantity")]
        public int BoxQuantity { get; set; }

        [JsonProperty("deci")]
        public double Deci { get; set; }
    }

}
