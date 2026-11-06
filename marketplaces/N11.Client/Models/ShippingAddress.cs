using Newtonsoft.Json;

namespace N11.Client
{
    public class ShippingAddress
    {
        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("district")]
        public string District { get; set; }

        [JsonProperty("neighborhood")]
        public string Neighborhood { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("gsm")]
        public string Gsm { get; set; }

        [JsonProperty("tcId")]
        public string TcId { get; set; }

        [JsonProperty("postalCode")]
        public string PostalCode { get; set; }
    }
}
