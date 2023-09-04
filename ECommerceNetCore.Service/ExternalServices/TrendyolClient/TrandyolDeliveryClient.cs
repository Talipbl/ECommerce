using ECommerce.Service.ExternalServices.TrendyolClient.Models.DeliveryModels;
using ECommerce.Service.Models;
using System.Net;
using System.Text;

namespace ECommerce.Service.ExternalServices.TrendyolClient
{
    //bkz: https://developers.trendyol.com/docs/marketplace/ortak-etiket-entegrasyonu/ortak-etiket-entegrasyonu
    public class TrandyolDeliveryClient
    {
        private TrendyolHttpClient Client { get; set; }
        private string SupplierId { get; set; } = "836049";
        public TrandyolDeliveryClient()
        {
            //TO-DO: Buradaki bilgiler veri tabanına kaydedilip oradan çekilecek.
            string auth = Convert.ToBase64String(Encoding.ASCII.GetBytes("mhnqkT7WsnoMmpca49NY:yYxBaDjJw1QaRykToWHt"));

            ApiAuthenticationModel authorization = new ApiAuthenticationModel()
            {
                ApiKey = "mhnqkT7WsnoMmpca49NY",
                ApiSecretKey = "yYxBaDjJw1QaRykToWHt",
                Authorization = $"Basic {auth}"
            };

            Client = new TrendyolHttpClient("https://sellerpublic-sdc.trendyol.com", SupplierId, authorization);
        }

        /// <summary>
        /// Barkod talebini ilgili sipariş paketine picking veya invoiced statüsü besledikten sonra yapmanız tavsiye edilmektedir.
        /// Format olarak şu an için sadece ZPL formatı bulunmaktadır.
        /// stage https://stagesellerpublic.trendyol.com/delivery-delivery-external-service/sellers/{sellerId}/common-label/{cargoTrackingNumber}
        /// prod https://sellerpublic-sdc.trendyol.com/delivery-delivery-external-service/sellers/{sellerId}/common-label/{cargoTrackingNumber}
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cargoTrackingNumber"></param>
        /// <returns></returns>
        public async Task<RootResponseModel<object>> CreateCommonLabel(CreateCommonLabelRequestModel request, string cargoTrackingNumber)
        {
            return await Task.Run(()=>Client.PostAsync<object>(request,$"/delivery-delivery-external-service/sellers/{SupplierId}/common-label/{cargoTrackingNumber}"));
        }

        /// <summary>
        /// Tarafınıza çoklu koliler için birden fazla etiket dönecektir. Tek koli olması durumunda tek ZPL dönecektir.
        /// stage https://stagesellerpublic.trendyol.com/delivery-delivery-external-service/sellers/{sellerId}/common-label/{cargoTrackingNumber}
        /// prod https://sellerpublic-sdc.trendyol.com/delivery-delivery-external-service/sellers/{sellerId}/common-label/{cargoTrackingNumber}
        /// </summary>
        /// <param name="cargoTrackingNumber"></param>
        /// <returns></returns>
        public async Task<RootResponseModel<GetCommonLabelResponseModel>> GetCommonLabel(string cargoTrackingNumber)
        {
            return await Task.Run(() => Client.GetAsync<GetCommonLabelResponseModel>($"/delivery-delivery-external-service/sellers/{SupplierId}/common-label/{cargoTrackingNumber}"));
        }
    }
}
