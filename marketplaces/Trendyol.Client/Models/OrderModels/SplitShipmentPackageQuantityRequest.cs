using Newtonsoft.Json;

namespace Trendyol.Client
{
    public class SplitShipmentPackageQuantityRequest
    {
        [JsonProperty("splitPackages")]
        public List<SplitPackage> SplitPackages { get; set; }

        public class SplitPackage
        {
            [JsonProperty("packageDetails")]
            public List<PackageDetail> PackageDetails { get; set; }

            public class PackageDetail
            {
                [JsonProperty("orderLineId")]
                public int OrderLineId { get; set; }

                [JsonProperty("quantities")]
                public int Quantities { get; set; }
            }
        }
    }
}
