namespace ECommerce.Service.ExternalServices.TrendyolClient.Models.ClaimReturnModels
{
    public class CreateClaimResponseModel
    {
        public string ClaimId { get; set; }
        public string CargoTrackingNumber { get; set; }
        public List<string> ClaimItemIds { get; set; }
    }
}
