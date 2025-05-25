using Newtonsoft.Json;

namespace N11.Client
{
    public class Order
    {
        [JsonProperty("billingAddress")]
        public BillingAddress BillingAddress { get; set; }

        [JsonProperty("shippingAddress")]
        public ShippingAddress ShippingAddress { get; set; }

        [JsonProperty("orderNumber")]
        public string OrderNumber { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("customerEmail")]
        public string CustomerEmail { get; set; }

        [JsonProperty("customerfullName")]
        public string CustomerfullName { get; set; }

        [JsonProperty("customerId")]
        public int CustomerId { get; set; }

        [JsonProperty("taxId")]
        public object TaxId { get; set; }

        [JsonProperty("taxOffice")]
        public object TaxOffice { get; set; }

        [JsonProperty("tcIdentityNumber")]
        public string TcIdentityNumber { get; set; }

        [JsonProperty("cargoSenderNumber")]
        public object CargoSenderNumber { get; set; }

        [JsonProperty("cargoTrackingNumber")]
        public string CargoTrackingNumber { get; set; }

        [JsonProperty("cargoTrackingLink")]
        public string CargoTrackingLink { get; set; }

        [JsonProperty("shipmentCompanyId")]
        public int ShipmentCompanyId { get; set; }

        [JsonProperty("cargoProviderName")]
        public string CargoProviderName { get; set; }

        [JsonProperty("shipmentMethod")]
        public int ShipmentMethod { get; set; }

        [JsonProperty("installmentChargeWithVATprice")]
        public double InstallmentChargeWithVATprice { get; set; }

        [JsonProperty("lines")]
        public List<OrderProduct> Lines { get; set; }

        [JsonProperty("lastModifiedDate")]
        public long LastModifiedDate { get; set; }

        [JsonProperty("agreedDeliveryDate")]
        public long AgreedDeliveryDate { get; set; }

        [JsonProperty("totalAmount")]
        public double TotalAmount { get; set; }

        [JsonProperty("totalDiscountAmount")]
        public double TotalDiscountAmount { get; set; }

        [JsonProperty("packageHistories")]
        public List<PackageHistory> PackageHistories { get; set; }

        [JsonProperty("shipmentPackageStatus")]
        public string ShipmentPackageStatus { get; set; }

        [JsonProperty("sellerId")]
        public int SellerId { get; set; }
    }
}
