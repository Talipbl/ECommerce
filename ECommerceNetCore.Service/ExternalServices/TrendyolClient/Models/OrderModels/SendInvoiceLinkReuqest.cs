namespace ECommerceNetCore.Service.ExternalServices.TrendyolClient
{
    public class SendInvoiceLinkReuqest
    {
        public string InvoiceLink { get; set; }
        public long ShipmentPackageId { get; set; }
        public long InvoiceDateTime { get; set; }
        public string InvoiceNumber { get; set; }
    }

}
