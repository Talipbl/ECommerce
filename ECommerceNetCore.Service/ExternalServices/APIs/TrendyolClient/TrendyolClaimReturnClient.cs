using ECommerceNetCore.Application.Aspects;
using System.Net;
using System.Text;
using ECommerceNetCore.Service.Models;
using ECommerceNetCore.Service.ExternalServices.APIs.TrendyolClient.Models.ClaimReturnModels;

namespace ECommerceNetCore.Service.ExternalServices.APIs.TrendyolClient
{
    [SecurityProtocolAspect(ProtocolType = SecurityProtocolType.Tls12)]
    public class TrendyolClaimReturnClient
    {
        private TrendyolHttpClient Client { get; set; }
        private string SupplierId { get; set; } = "836049";
        public TrendyolClaimReturnClient()
        {
            //TO-DO: Buradaki bilgiler veri tabanına kaydedilip oradan çekilecek.
            string auth = Convert.ToBase64String(Encoding.ASCII.GetBytes("mhnqkT7WsnoMmpca49NY:yYxBaDjJw1QaRykToWHt"));

            ApiAuthorizationModel authorization = new ApiAuthorizationModel()
            {
                ApiKey = "mhnqkT7WsnoMmpca49NY",
                ApiSecretKey = "yYxBaDjJw1QaRykToWHt",
                Authorization = $"Basic {auth}"
            };

            Client = new TrendyolHttpClient("https://api.trendyol.com", SupplierId, authorization);
        }
        public async Task<HttpResponseModel<GetClaimsResponseModel>> GetClaims()
        {
            return await Task.Run(() => Client.GetAsync<GetClaimsResponseModel>($"/sapigw/suppliers/{SupplierId}/claims?claimItemStatus="));
        }
        public async Task<HttpResponseModel<CreateClaimResponseModel>> CreateClaim(CreateClaimRequestModel request)
        {
            return await Task.Run(() => Client.PostAsync<CreateClaimResponseModel>(request,$"/sapigw/suppliers/{SupplierId}/claims/create"));
        }
        public async Task<HttpResponseModel<object>> ApproveClaimLineItems(ApproveClaimLineItemsRequest request,string claimId)
        {
            return await Task.Run(() => Client.PutAsync<object>(request, $"/sapigw/claims/{claimId}/items/approve"));
        }
        public async Task<HttpResponseModel<object>> CreateClaimIssue(string claimId,string claimIssueReasonId,string claimItemIdList, string test)
        {
            return await Task.Run(() => Client.PostAsync<object>(null, $"/sapigw/claims/{claimId}/issue?claimIssueReasonId={claimIssueReasonId}&claimItemIdList={claimItemIdList}&description={test}"));
        }
        public async Task<HttpResponseModel<object>> GetClaimsIssueReasons(string claimItemsId)
        {
            return await Task.Run(() => Client.GetAsync<object>($"/integration/oms/core/sellers/{SupplierId}/claims/items/{claimItemsId}/audit"));
        }
    }
}
