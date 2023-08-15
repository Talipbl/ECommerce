namespace ECommerceNetCore.Service.ExternalServices.APIs.TrendyolClient.Models.ClaimReturnModels
{
    public class CreateClaimResponseModel
    {
        public string ClaimId { get; set; }
        public string CargoTrackingNumber { get; set; }
        public List<string> ClaimItemIds { get; set; }
    }
}
