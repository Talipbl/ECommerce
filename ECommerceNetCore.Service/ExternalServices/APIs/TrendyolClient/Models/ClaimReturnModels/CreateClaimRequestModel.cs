namespace ECommerceNetCore.Service.ExternalServices.APIs.TrendyolClient
{
    public class CreateClaimRequestModel
    {
        public List<ClaimItem> ClaimItems { get; set; }
        public int CustomerId { get; set; }
        public bool ExcludeListing { get; set; }
        public bool ForcePackageCreation { get; set; }
        public string OrderNumber { get; set; }
        public int ShipmentCompanyId { get; set; }
        public class ClaimItem
        {
            public string Barcode { get; set; }
            public string CustomerNote { get; set; }
            public int Quantity { get; set; }
            public int ReasonId { get; set; }
        }
    }
}
