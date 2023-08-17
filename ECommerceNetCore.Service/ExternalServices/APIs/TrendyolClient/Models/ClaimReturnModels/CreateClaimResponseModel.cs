namespace ECommerceNetCore.Service.ExternalServices.APIs.TrendyolClient
{
    public class CreateClaimResponseModel
    {
        public string ClaimId { get; set; }
        public string CargoTrackingNumber { get; set; }
        public List<string> ClaimItemIds { get; set; }
    }
}
