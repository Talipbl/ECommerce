namespace ECommerce.Trendyol.Order
{
    public class OrderQueryParametersModelDTO
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
        public long? SupplierId { get; set; }
        public string OrderNumber { get; set; }
        public string Status { get; set; }
        public string OrderByField { get; set; }
        public string OrderByDirection { get; set; }
        public long? ShipmentPackageIds { get; set; }
    }
}
