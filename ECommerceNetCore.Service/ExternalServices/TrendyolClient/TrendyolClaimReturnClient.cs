using ECommerceNetCore.Application.Aspects;
using System.Net;
using System.Text;

namespace ECommerceNetCore.Service.ExternalServices.TrendyolClient
{
    //bkz: https://developers.trendyol.com/docs/category/i%CC%87ade-entegrasyonu

    [SecurityProtocolAspect(ProtocolType = SecurityProtocolType.Tls12)]
    public class TrendyolClaimReturnClient
    {
        private TrendyolHttpClient Client { get; set; }
        private string SupplierId { get; set; } = "836049";
        public TrendyolClaimReturnClient()
        {
            //TO-DO: Buradaki bilgiler veri tabanına kaydedilip oradan çekilecek.
            string auth = Convert.ToBase64String(Encoding.ASCII.GetBytes("mhnqkT7WsnoMmpca49NY:yYxBaDjJw1QaRykToWHt"));

            ApiAuthenticationModel authorization = new ApiAuthenticationModel()
            {
                ApiKey = "mhnqkT7WsnoMmpca49NY",
                ApiSecretKey = "yYxBaDjJw1QaRykToWHt",
                Authorization = $"Basic {auth}"
            };

            Client = new TrendyolHttpClient("https://api.trendyol.com", SupplierId, authorization);
        }

        /// <summary>
        /// Trendyol sisteminde iadesi oluşan siparişleri bu metod yardımıyla çekebilirsiniz.
        /// </summary>
        /// <param name="queries"></param>
        /// <returns></returns>
        public async Task<RootResponseModel<GetClaimsResponseModel>> GetClaims(ClaimsQueryParametersModel queries)
        {
            string queryString = JsonHelper.BuildQueryString(queries);
            return await Task.Run(() => Client.GetAsync<GetClaimsResponseModel>($"/sapigw/suppliers/{SupplierId}/claims?{queryString}"));
        }

        /// <summary>
        /// Deponuza iade kodu alınmadan gelen sipariş paketlerin iade talep paketlerini oluşturmak için kullanabilirsiniz. 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<RootResponseModel<CreateClaimResponseModel>> CreateClaim(CreateClaimRequestModel request)
        {
            return await Task.Run(() => Client.PostAsync<CreateClaimResponseModel>(request, $"/sapigw/suppliers/{SupplierId}/claims/create"));
        }

        /// <summary>
        /// Trendyol Paneli üzerinden iade siparişleri onaylama işlemini yapar.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="claimId"></param>
        /// <returns></returns>
        public async Task<RootResponseModel<string>> ApproveClaimLineItems(ApproveClaimLineItemsRequest request, string claimId)
        {
            return await Task.Run(() => Client.PutAsync<string>(request, $"/sapigw/claims/{claimId}/items/approve"));
        }

        /// <summary>
        /// Trendyol Paneli üzerinden iade siparişlerine ret talebi oluşturma işlemini yaparç
        /// </summary>
        /// <param name="claimId"></param>
        /// <param name="claimIssueReasonId"></param>
        /// <param name="claimItemIdList"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public async Task<RootResponseModel<string>> CreateClaimIssue(string claimId, string claimIssueReasonId, string claimItemIdList, string description)
        {
            return await Task.Run(() => Client.PostAsync<string>(default, $"/sapigw/claims/{claimId}/issue?claimIssueReasonId={claimIssueReasonId}&claimItemIdList={claimItemIdList}&description={description}"));
        }

        /// <summary>
        /// <paramref name="CreateClaimIssue"/> servisine yapılacak olan isteklerde gönderilecek claimIssueReasonId değerine bu servisi kullanarak ulaşabilirsiniz.
        /// </summary>
        /// <param name="claimItemsId"></param>
        /// <returns></returns>
        public async Task<RootResponseModel<object>> GetClaimsIssueReasons(string claimItemsId)
        {
            return await Task.Run(() => Client.GetAsync<object>($"/sapigw/claim-issue-reasons"));
        }

        /// <summary>
        /// Trendyol sisteminde iadesi oluşan siparişlerin süreç ve statü geçiş durumlarını tarih, işlem yapılan platform ve işlem yapan kişi bazında bu servis üzerinden kontrol eder.
        /// </summary>
        /// <param name="claimItemsId"></param>
        /// <returns></returns>
        public async Task<RootResponseModel<GetClaimAuditsResponse>> GetClaimAudit(string claimItemsId)
        {
            return await Task.Run(() => Client.GetAsync<GetClaimAuditsResponse>($"/integration/oms/core/sellers/{SupplierId}/claims/items/{claimItemsId}/audit"));
        }
    }
}
