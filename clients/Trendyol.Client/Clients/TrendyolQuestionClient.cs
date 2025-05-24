namespace Trendyol.Client
{
    /// <summary>
    /// <see cref="https://developers.trendyol.com/docs/category/soru-cevap-entegrasyonu"
    /// </summary>
    public class TrendyolQuestionClient
    {

        private BaseHttpClient Client { get; set; }

        readonly string URL = "https://api.trendyol.com";
        readonly string PREFIX = "/sapigw";
        readonly string _supplierId;
        public TrendyolQuestionClient(ApiAuthentication authentication)
        {
            _supplierId = authentication.SellerId;
            Client = new BaseHttpClient(URL, _supplierId, authentication);
        }

        /// <summary>
        /// Trendyol üzerinden müşterilerin iş ortaklarımıza sormuş olduğu soruların tümünü bu servis aracılığı ile çekebilirsiniz.
        /// </summary>
        /// <param name="queries"></param>
        /// <returns></returns>
        public async Task<RootResponseModel<GetQuestionsResponseModel>> GetQuestions(QuestionQueryParametersModel queries)
        {
            string queryString = JsonHelper.BuildQueryString(queries);
            return await Client.GetAsync<GetQuestionsResponseModel>($"{PREFIX}/suppliers/{_supplierId}/questions/filter?{queryString}");
        }

        /// <summary>
        /// GetQuestions servisinden dönen sorunun id değeri ile soruları tekil olarak çekip işlem yapabilirsiniz.
        /// </summary>
        /// <param name="questionId"></param>
        /// <returns></returns>
        public async Task<RootResponseModel<GetQuestionResponseModel>> GetQuestion(string questionId)
        {
            return await Client.GetAsync<GetQuestionResponseModel>($"{PREFIX}/suppliers/{_supplierId}/questions/{questionId}");
        }

        /// <summary>
        /// Trendyol Müşteri Sorularını Çekme Servisi üzerinden çekmiş olduğunuz sorulara bu servis aracılığı ile cevap verebilirsiniz.
        /// </summary>
        /// <remarks>Cevap mesajı minimum 10, maksimum 2000 karakter aralığında olmalıdır.</remarks>
        /// <param name="questionId"></param>
        /// <returns>HTTP Status Code</returns>
        public async Task<RootResponseModel<string>> AnswerQuestion(string questionId, string message)
        {
            return await Client.PostAsync<string>(new QuestionMessageModel(message), $"{PREFIX}/suppliers/{_supplierId}/questions/{questionId}/answers");
        }
    }
}
