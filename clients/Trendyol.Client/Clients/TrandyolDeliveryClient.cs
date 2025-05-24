using System.Net;
using System.Text;

namespace Trendyol.Client
{
    /// <summary>
    /// <see cref="https://developers.trendyol.com/docs/Marketplaces/ortak-etiket-entegrasyonu/ortak-etiket-entegrasyonu"/>
    /// </summary>
    public class TrandyolDeliveryClient
    {
        private BaseHttpClient Client { get; set; }

        readonly string URL = "https://sellerpublic-sdc.trendyol.com";
        private readonly string _supplierId;
        public TrandyolDeliveryClient(ApiAuthentication authentication)
        {
            _supplierId = authentication.SellerId;
            Client = new BaseHttpClient(URL, _supplierId, authentication);
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
            return await Client.PostAsync<object>(request, $"/delivery-delivery-external-service/sellers/{_supplierId}/common-label/{cargoTrackingNumber}");
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
            return await Client.GetAsync<GetCommonLabelResponseModel>($"/delivery-delivery-external-service/sellers/{_supplierId}/common-label/{cargoTrackingNumber}");
        }
    }
}
