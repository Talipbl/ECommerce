namespace ECommerceNetCore.Service.ExternalServices.APIs.TrendyolClient
{
    public class SplitShipmentPackageMultiSplintRequest
    {
        public List<SplitGroup> SplitGroups { get; set; }
        public class SplitGroup
        {
            public List<int> OrderLineIds { get; set; }
        }
    }

}
