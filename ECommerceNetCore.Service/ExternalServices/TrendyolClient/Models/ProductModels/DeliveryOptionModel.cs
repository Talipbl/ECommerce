using Newtonsoft.Json;

namespace ECommerceNetCore.Service.ExternalServices.TrendyolClient
{
    public class DeliveryOptionModel
    {
        [JsonProperty("deliveryDuration")]
        public int DeliveryDuration { get; set; }

        [JsonProperty("fastDeliveryType")]
        public string FastDeliveryType { get; set; }
    }
}
