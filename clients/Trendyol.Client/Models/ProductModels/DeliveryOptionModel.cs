using Newtonsoft.Json;

namespace Trendyol.Client
{
    public class DeliveryOptionModel
    {
        [JsonProperty("deliveryDuration")]
        public int DeliveryDuration { get; set; }

        [JsonProperty("fastDeliveryType")]
        public string FastDeliveryType { get; set; }
    }
}
