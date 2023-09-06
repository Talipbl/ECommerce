using Newtonsoft.Json;

namespace ECommerce.Service.ExternalServices.TrendyolClient.Models.ProductModels
{
    public class DeliveryOptionModel
    {
        [JsonProperty("deliveryDuration")]
        public int DeliveryDuration { get; set; }

        [JsonProperty("fastDeliveryType")]
        public string FastDeliveryType { get; set; }
    }
}
