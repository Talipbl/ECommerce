using Newtonsoft.Json;

namespace Trendyol.Client
{
    public class SendInvoiceLinkReuqest
    {
        [JsonProperty("invoiceLink")]
        public string InvoiceLink { get; set; }

        [JsonProperty("shipmentPackageId")]
        public long ShipmentPackageId { get; set; }

        [JsonProperty("invoiceDateTime")]
        public long InvoiceDateTime { get; set; }

        [JsonProperty("invoiceNumber")]
        public string InvoiceNumber { get; set; }
    }

}
