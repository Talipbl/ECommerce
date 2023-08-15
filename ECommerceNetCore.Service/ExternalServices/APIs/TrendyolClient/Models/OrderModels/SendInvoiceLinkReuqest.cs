namespace ECommerceNetCore.Service.ExternalServices.APIs.TrendyolClient.Models.OrderModels
{
    public class SendInvoiceLinkReuqest
    {
        public SendInvoiceLinkReuqest(SendInvoiceLinkReuqest reuqest)
        {
            InvoiceLink = reuqest.InvoiceLink;
            ShipmentPackageId = reuqest.ShipmentPackageId;
            InvoiceDateTime = reuqest.InvoiceDateTime;
            InvoiceNumber = reuqest.InvoiceNumber;
        }

        public string InvoiceLink { get; set; }
        public long ShipmentPackageId { get; set; }
        public long InvoiceDateTime { get; set; }
        public string InvoiceNumber { get; set; }
    }

}
