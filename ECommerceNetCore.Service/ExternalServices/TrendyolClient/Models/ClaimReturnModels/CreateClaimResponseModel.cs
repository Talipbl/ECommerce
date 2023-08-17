namespace ECommerceNetCore.Service.ExternalServices.TrendyolClient
{
    public class CreateClaimResponseModel
    {
        public string ClaimId { get; set; }
        public string CargoTrackingNumber { get; set; }
        public List<string> ClaimItemIds { get; set; }
    }
}
