namespace ECommerceNetCore.Service.ExternalServices.TrendyolClient
{
    public class SplitShipmentPackageByQuantityRequest
    {
        public List<QuantitySplitModel> QuantitySplit { get; set; }
        public class QuantitySplitModel
        {
            public int OrderLineId { get; set; }
            public List<int> Quantities { get; set; }
        }
    }

}
