using Newtonsoft.Json;

namespace ECommerce.Service.ExternalServices.TrendyolClient.Models.ClaimReturnModels
{
    public class CreateClaimRequestModel
    {
        [JsonProperty("claimItems")]
        public List<ClaimItem> ClaimItems { get; set; }

        [JsonProperty("customerId")]
        public int CustomerId { get; set; }

        [JsonProperty("excludeListing")]
        public bool ExcludeListing { get; set; }

        [JsonProperty("forcePackageCreation")]
        public bool ForcePackageCreation { get; set; }

        [JsonProperty("orderNumber")]
        public string OrderNumber { get; set; }

        [JsonProperty("shipmentCompanyId")]
        public int ShipmentCompanyId { get; set; }

        public class ClaimItem
        {
            [JsonProperty("barcode")]
            public string Barcode { get; set; }

            [JsonProperty("customerNote")]
            public string CustomerNote { get; set; }

            [JsonProperty("quantity")]
            public int Quantity { get; set; }

            [JsonProperty("reasonId")]
            public int ReasonId { get; set; }
        }
    }
}
