namespace ECommerceNetCore.Service.ExternalServices.APIs.TrendyolClient
{
    //Buraya bakılacak
    public class SplitShipmentPackageQuantityRequest
    {
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
