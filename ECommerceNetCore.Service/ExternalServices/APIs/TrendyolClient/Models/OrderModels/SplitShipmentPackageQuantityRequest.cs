namespace ECommerceNetCore.Service.ExternalServices.APIs.TrendyolClient.Models.OrderModels
{
    //Buraya bakılacak
    public class SplitShipmentPackageQuantityRequest
    {
        public SplitShipmentPackageQuantityRequest(SplitShipmentPackageQuantityRequest request)
        {
            SplitPackages = request.SplitPackages;
        }

        public List<SplitPackage> SplitPackages { get; set; }
        public class SplitPackage
        {
            public List<PackageDetail> PackageDetails { get; set; }
            public class PackageDetail
            {
                public int OrderLineId { get; set; }
                public int Quantities { get; set; }
            }
        }
    }

}
