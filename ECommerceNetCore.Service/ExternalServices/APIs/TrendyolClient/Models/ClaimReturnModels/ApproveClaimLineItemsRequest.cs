namespace ECommerceNetCore.Service.ExternalServices.APIs.TrendyolClient.Models.ClaimReturnModels
{
    public class ApproveClaimLineItemsRequest
    {
        public List<string> ClaimLineItemIdList { get; set; }
        public ParamsModel Params { get; set; }

        public class ParamsModel
        {
        }
    }
}
