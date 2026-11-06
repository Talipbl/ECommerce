using System.Net;
using System.Text;

namespace Trendyol.Client
{
    /// <summary>
    /// <see cref="https://developers.trendyol.com/docs/category/i%CC%87ade-entegrasyonu"/>
    /// </summary>
    public class TrendyolClaimReturnClient
    {
        private BaseHttpClient Client { get; set; }

        readonly string URL = "https://api.trendyol.com";
        readonly string PREFIX = "/sapigw";
        private readonly string _supplierId;
        public TrendyolClaimReturnClient(ApiAuthentication authentication)
        {
            _supplierId = authentication.SellerId;
            Client = new BaseHttpClient(URL, _supplierId, authentication);
        }

        /// <summary>
        /// Trendyol sisteminde iadesi oluşan siparişleri bu metod yardımıyla çekebilirsiniz.
        /// </summary>
        /// <param name="queries"></param>
        /// <returns></returns>
        public async Task<RootResponseModel<GetClaimsResponseModel>> GetClaims(ClaimsQueryParametersModel queries)
        {
            string queryString = JsonHelper.BuildQueryString(queries);
            return await Client.GetAsync<GetClaimsResponseModel>($"{PREFIX}/suppliers/{_supplierId}/claims?{queryString}");
        }

        /// <summary>
        /// Deponuza iade kodu alınmadan gelen sipariş paketlerin iade talep paketlerini oluşturmak için kullanabilirsiniz. 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<RootResponseModel<CreateClaimResponseModel>> CreateClaim(CreateClaimRequestModel request)
        {
            return await Client.PostAsync<CreateClaimResponseModel>(request, $"{PREFIX}/suppliers/{_supplierId}/claims/create");
        }

        /// <summary>
        /// Trendyol Paneli üzerinden iade siparişleri onaylama işlemini yapar.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="claimId"></param>
        /// <returns></returns>
        public async Task<RootResponseModel<string>> ApproveClaimLineItems(ApproveClaimLineItemsRequest request, string claimId)
        {
            return await Client.PutAsync<string>(request, $"{PREFIX}/claims/{claimId}/items/approve");
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
            return await Client.PostAsync<string>(default, $"{PREFIX}/claims/{claimId}/issue?claimIssueReasonId={claimIssueReasonId}&claimItemIdList={claimItemIdList}&description={description}");
        }

        /// <summary>
        /// <paramref name="CreateClaimIssue"/> servisine yapılacak olan isteklerde gönderilecek claimIssueReasonId değerine bu servisi kullanarak ulaşabilirsiniz.
        /// </summary>
        /// <param name="claimItemsId"></param>
        /// <returns></returns>
        public async Task<RootResponseModel<object>> GetClaimsIssueReasons(string claimItemsId)
        {
            return await Client.GetAsync<object>($"{PREFIX}/claim-issue-reasons");
        }

        /// <summary>
        /// Trendyol sisteminde iadesi oluşan siparişlerin süreç ve statü geçiş durumlarını tarih, işlem yapılan platform ve işlem yapan kişi bazında bu servis üzerinden kontrol eder.
        /// </summary>
        /// <param name="claimItemsId"></param>
        /// <returns></returns>
        public async Task<RootResponseModel<GetClaimAuditsResponse>> GetClaimAudit(string claimItemsId)
        {
            return await Client.GetAsync<GetClaimAuditsResponse>($"/integration/oms/core/sellers/{_supplierId}/claims/items/{claimItemsId}/audit");
        }
    }
}
