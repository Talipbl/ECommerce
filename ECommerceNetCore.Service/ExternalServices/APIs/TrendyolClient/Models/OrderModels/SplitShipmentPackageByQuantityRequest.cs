namespace ECommerceNetCore.Service.ExternalServices.APIs.TrendyolClient.Models.OrderModels
{
    public class SplitShipmentPackageByQuantityRequest
    {
        public SplitShipmentPackageByQuantityRequest(SplitShipmentPackageByQuantityRequest request)
        {
            QuantitySplit = request.QuantitySplit;
        }

        public List<QuantitySplitModel> QuantitySplit { get; set; }
        public class QuantitySplitModel
        {
            public int OrderLineId { get; set; }
            public List<int> Quantities { get; set; }
        }
    }

}
