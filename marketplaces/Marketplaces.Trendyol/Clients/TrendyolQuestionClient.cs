using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Marketplaces.Trendyol
{
    // bkz: https://developers.trendyol.com/docs/category/soru-cevap-entegrasyonu

    public class TrendyolQuestionClient
    {
        private TrendyolHttpClient Client { get; set; }
        private string SupplierId { get; set; } = "836049";
        public TrendyolQuestionClient()
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
        /// Trendyol üzerinden müşterilerin iş ortaklarımıza sormuş olduğu soruların tümünü bu servis aracılığı ile çekebilirsiniz.
        /// </summary>
        /// <param name="queries"></param>
        /// <returns></returns>
        public async Task<RootResponseModel<GetQuestionsResponseModel>> GetQuestions(QuestionQueryParametersModel queries)
        {
            string queryString = JsonHelper.BuildQueryString(queries);
            return await Task.Run(() => Client.GetAsync<GetQuestionsResponseModel>($"/sapigw/suppliers/{SupplierId}/questions/filter?{queryString}"));
        }

        /// <summary>
        /// GetQuestions servisinden dönen sorunun id değeri ile soruları tekil olarak çekip işlem yapabilirsiniz.
        /// </summary>
        /// <param name="questionId"></param>
        /// <returns></returns>
        public async Task<RootResponseModel<GetQuestionResponseModel>> GetQuestion(string questionId)
        {
            return await Task.Run(() => Client.GetAsync<GetQuestionResponseModel>($"/sapigw/suppliers/{SupplierId}/questions/{questionId}"));
        }

        /// <summary>
        /// Trendyol Müşteri Sorularını Çekme Servisi üzerinden çekmiş olduğunuz sorulara bu servis aracılığı ile cevap verebilirsiniz.
        /// </summary>
        /// <remarks>Cevap mesajı minimum 10, maksimum 2000 karakter aralığında olmalıdır.</remarks>
        /// <param name="questionId"></param>
        /// <returns>HTTP Status Code</returns>
        public async Task<RootResponseModel<string>> AnswerQuestion(string questionId, string message)
        {
            return await Task.Run(() => Client.PostAsync<string>(new QuestionMessageModel(message), $"/sapigw/suppliers/{SupplierId}/questions/{questionId}/answers"));
        }
    }
}
