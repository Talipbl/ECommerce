using ECommerceNetCore.Application.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Azure.Core;
using System.Security.Claims;
using static System.Net.Mime.MediaTypeNames;

namespace ECommerceNetCore.Service.ExternalServices.TrendyolClient
{
    // bkz: https://developers.trendyol.com/docs/category/sipari%C5%9F-entegrasyonu

    [SecurityProtocolAspect(ProtocolType = SecurityProtocolType.Tls12)]
    public class TrendyolOrderClient
    {
        private TrendyolHttpClient Client { get; set; }
        private string SupplierId { get; set; } = "836049";
        public TrendyolOrderClient()
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

        /// <summary>
        /// Siparişleri getiren metot.
        /// </summary>
        /// <param name="queries">Model içerisinde istenilen filtreler doldurulup gönderilir.</param>
        /// <returns></returns>
        public async Task<RootResponseModel<GetOrdersResponseModel>> GetOrders(OrderQueryParametersModel queries)
        {
            string queryString = JsonHelper.BuildQueryString(queries);
            return await Task.Run(() => Client.GetAsync<GetOrdersResponseModel>($"/sapigw/suppliers/{SupplierId}/orders?{queryString}"));
        }

        /// <summary>
        /// Bu metot herhangi bir paket için çağırıldığında, artık Trendyol’un anlaşması üzerinden olan paket değil, tedarikçinin kendi anlaşması üzerinden yaptığı gönderinin durumu sorgulanmaya başlar.
        /// </summary>
        /// <param name="shipmentPackageId"></param>
        /// <returns>HTTP Status Code</returns>
        public async Task<RootResponseModel<object>> UpdateTrackingNumber(string shipmentPackageId)
        {
            return await Task.Run(() => Client.PutAsync<object>(new TrackingNumberModel(shipmentPackageId), $"/sapigw/suppliers/{SupplierId}/{shipmentPackageId}/update-tracking-number"));
        }

        /// <summary>
        /// Oluşturularan sipariş paketinin faturasının kesilmesi işleminin Trendyol’a bildirilebilmesi için kullanılır. Fatura kesme işleminin bildirilmesi, Trendyol Müşteri Hizmetlerine ulaşan, müşteri kaynaklı iptallerin önlenmesi için bir referanstır. Statü beslemelerini yaparken önce "Picking" sonra "Invoiced" statü beslemesi yapmanız gerekmektedir.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="shipmentPackageId"></param>
        /// <returns></returns>
        public async Task<RootResponseModel<object>> UpdatePackage(UpdatePackageRequest request, string shipmentPackageId)
        {
            return await Task.Run(() => Client.PutAsync<object>(request, $"/sapigw/suppliers/{SupplierId}/shipment-packages/{shipmentPackageId}"));
        }

        /// <summary>
        /// Tedarikçinin paket içerisindeki ürünlerden bir ya da birkaçını Tedarik Edememe kaynaklı iptal etmesi için kullanılır. Bu method yardımıyla yapılan bir iptal sonrası, iptal edilen paket bozularak yeni ID’li bir paket oluşturulacaktır.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="shipmentPackageId"></param>
        /// <returns></returns>
        public async Task<RootResponseModel<object>> SetFailureToSupply(FailureToSupplyReuqest request, string shipmentPackageId)
        {
            return await Task.Run(() => Client.PutAsync<object>(request, $"/integration/oms/core/sellers/{SupplierId}/shipment-packages/{shipmentPackageId}/items/unsupplied"));
        }

        /// <summary>
        /// Tedarikçi tarafından kendi sisteminde yaratılmış e-Arşiv ya da e-Fatura bilgisinin LİNK detayını Trendyol sistemine transfer etmek için bu method kullanılacaktır.
        /// </summary>
        /// <param name="request"></param>
        /// <remarks><u>YASAL ZORUNLULUK:</u> Bu servis ile gönderilen fatura bağlantılarının hukuki zorunluluk gereği 8 yıl boyunca erişilebilir durumda olması gereklidir.</remarks>
        /// <returns></returns>
        public async Task<RootResponseModel<string>> SendInvoiceLink(SendInvoiceLinkReuqest request)
        {
            return await Task.Run(() => Client.PostAsync<string>(request, $"/sapigw/suppliers/{SupplierId}/supplier-invoice-links"));
        }

        /// <summary>
        /// Bu servis ile Trendyol üzerinde oluşmuş siparişlerinizi birden fazla paket haline getirebilirsiniz. Bu servisi kulandıktan sonra sipariş numarasına bağlı yeni paketler "UnPacked" statüsünde, asenkron olarak oluşacaktır. Bu nedenle Sipariş Paketlerini Çekme servisinden tekrar güncel paketleri çekmelisiniz.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="shipmentPackageId"></param>
        ///<see href="https://developers.trendyol.com/docs/marketplace/siparis-entegrasyonu/siparis-paketlerini-bolme#post-splitmultipackagebyquantity"/>
        /// <returns></returns>
        public async Task<RootResponseModel<object>> MultiSplitShipmentPackageByQuantity(List<SplitShipmentPackageQuantityRequest> request, string shipmentPackageId)
        {
            return await Task.Run(() => Client.PostAsync<object>(request, $"/sapigw/suppliers/{SupplierId}/shipment-packages/{shipmentPackageId}/split-packages"));
        }

        /// <summary></summary>
        /// <param name="orderLineIds"></param>
        /// <param name="shipmentPackageId"></param>
        ///<see href="https://developers.trendyol.com/docs/marketplace/siparis-entegrasyonu/siparis-paketlerini-bolme#post-splitmultipackagebyquantity"/>
        /// <returns></returns>
        public async Task<RootResponseModel<object>> SplitShipmentPackage(string orderLineIds, string shipmentPackageId)
        {
            return await Task.Run(() => Client.PostAsync<object>(orderLineIds, $"/sapigw/suppliers/{SupplierId}/shipment-packages/{shipmentPackageId}/split"));
        }

        /// <summary>
        /// Tek Request İle Birden Fazla Paket Oluşturma
        /// </summary>
        /// <param name="request"></param>
        /// <param name="shipmentPackageId"></param>
        ///<see href="https://developers.trendyol.com/docs/marketplace/siparis-entegrasyonu/siparis-paketlerini-bolme#post-splitmultipackagebyquantity"/>
        /// <returns></returns>
        public async Task<RootResponseModel<object>> MultiSplitShipmentPackage(List<SplitShipmentPackageMultiSplintRequest> request, string shipmentPackageId)
        {
            return await Task.Run(() => Client.PostAsync<object>(request, $"/sapigw/suppliers/{SupplierId}/shipment-packages/{shipmentPackageId}/multi-split"));
        }

        /// <summary>
        /// Sipariş Paketlerini Barkod Bazlı Bölme
        /// </summary>
        /// <param name="request"></param>
        /// <param name="shipmentPackageId"></param>
        ///<see href="https://developers.trendyol.com/docs/marketplace/siparis-entegrasyonu/siparis-paketlerini-bolme#post-splitmultipackagebyquantity"/>
        /// <returns></returns>
        public async Task<RootResponseModel<object>> QuantitySplitShipmentPackage(SplitShipmentPackageByQuantityRequest request, string shipmentPackageId)
        {
            return await Task.Run(() => Client.PostAsync<object>(request, $"/sapigw/suppliers/{SupplierId}/shipment-packages/{shipmentPackageId}/quantity-split"));
        }

        /// <summary>
        /// Bu servis ile UPS Kargo , Horoz ve CEVA Lojistik firmalarına ait sipariş paketleriniz için desi ve koli bilgisi besleyebilirsiniz.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="shipmentPackageId"></param>
        /// <returns></returns>
        public async Task<RootResponseModel<object>> UpdateBoxInfo(UpdateBoxInfoRequest request, string shipmentPackageId)
        {
            return await Task.Run(() => Client.PutAsync<object>(request, $"/sapigw/suppliers/{SupplierId}/shipment-packages/{shipmentPackageId}/box-info"));
        }

        /// <summary>
        /// - Sipariş paketini gönderdikten sonra elinizde olan kargo takip linki ile besleme yapabilirsiniz. Bu isteği başarılı bir şekilde ilettikten sonra sipariş otomatik olarak "Shipped" (Taşıma Durumunda) statüsüne geçecektir. <br /> - <paramref name="IsPhoneNumber"/> : true olan alternatif teslimat gönderimleri için <paramref name="Deci"/> ve <paramref name="BoxQuantity"/> bilgisinin body içerisinde gönderilmesi zorunludur.
        /// </summary>
        /// <param name="request"><paramref name="DigitalCode"/> alanı 6-120 karakter arasında olmalıdır.</param>
        /// <returns>HTTP Status Code</returns>
        public async Task<RootResponseModel<object>> ProcessAlternativeDelivery(ProcessAlternativeDeliveryRequest request, string shippmentId)
        {
            return await Task.Run(() => Client.PutAsync<object>(request, $"/sapigw/suppliers/{SupplierId}/shipment-packages/{shippmentId}/alternative-delivery"));
        }

        /// <summary>
        /// Alternatif Teslimat ile Gönderilmiş Paketi Teslim Etme
        /// </summary>
        /// <param name="request"></param>
        /// <param name="shippmentId"></param>
        /// <returns>HTTP Status Code</returns>
        public async Task<RootResponseModel<object>> ManuelDeliver(string cargoTrackingNumber)
        {
            return await Task.Run(() => Client.PutAsync<object>(default, $"/sapigw/suppliers/{SupplierId}/manual-deliver/{cargoTrackingNumber}"));
        }

        /// <summary>
        /// Bu servisi, tarafınızdan "shipped" statüsüne geçirilip müşteriye teslim edilemediği durumda deponuza geri dönen ve bu sebeple "delivered" statüsüne geçirilemeyen siparişler için kullanabilirsiniz. 
        /// </summary>
        /// <param name="cargoTrackingNumber"></param>
        /// <returns></returns>
        public async Task<RootResponseModel<object>> ManuelReturn(string cargoTrackingNumber)
        {
            return await Task.Run(() => Client.PutAsync<object>(default, $"/sapigw/suppliers/{SupplierId}/manual-return/{cargoTrackingNumber}"));
        }

        /// <summary>
        /// - Ürünlerini yetkili servise kargolayan satıcılarımızın bu servisi çağırmaları gerekmektedir. <br /> - Lojistik firmalarıyla Tedarikçi Öder entegrasyonu yapan ve ürünlerini yetkili servise kargolayan satıcılarımızın bu servisi çağırmaları gerekmektedir. <b>(Mevcut durumda lojistik firmalarından sadece Horoz Lojistik ile tedarikçi öder çalışmamız bulunmaktadır.)</b>
        /// </summary>
        /// <param name="shipmentPackageId"></param>
        /// <returns></returns>
        public async Task<RootResponseModel<object>> DeliveredByService(string shipmentPackageId)
        {
            return await Task.Run(() => Client.PutAsync<object>(default, $"/sapigw/suppliers/{SupplierId}/shipment-packages/{shipmentPackageId}/delivered-by-service stage"));
        }

        /// <summary>
        /// Bu metod sipariş paketlerinin kargo firmalarının değiştirilmesi için kullanılmaktadır.
        /// </summary>
        /// <param name="cargoProvider"></param>
        /// <param name="shipmentPackageId"></param>
        /// <returns></returns>
        public async Task<RootResponseModel<object>> ChangeCargoProvider(CargoProvider cargoProvider, string shipmentPackageId)
        {
            return await Task.Run(() => Client.PutAsync<object>(new ChangeCargoProviderRequest(cargoProvider.ToString()), $"/sapigw/suppliers/{SupplierId}/shipment-packages/{shipmentPackageId}/cargo-providers"));
        }

        /// <summary>
        /// Bu servis sadece Trendyol Express kullanan satıcılarımız için geçerli olacaktır. Bu servis ile Sipariş Paketlerini Çekme servisinden dönen "WarehouseId" alanı güncellenebilecektir.
        /// </summary>
        /// <param name="warehouseId"></param>
        /// <param name="shipmentPackageId"></param>
        /// <param name="packageId"></param>
        /// <remarks><b>Eğer sevkiyat adresi eklenmesi isteniyor ise satıcı paneli üzerinden ekleme yapılabilmektedir.</b></remarks>
        /// <returns></returns>
        public async Task<RootResponseModel<string>> UpdateWarehouse(int warehouseId, string shipmentPackageId, string packageId)
        {
            return await Task.Run(() => Client.PutAsync<string>(new UpdateWarehouseRequest(warehouseId), $"/sapigw/suppliers/{SupplierId}/shipment-packages/{shipmentPackageId}/shipment-packages/{packageId}/warehouse"));
        }

        /// <summary>
        /// Bu servis üzerinden dileyen satıcılar sipariş paketleri için ek tedarik süresi tanımlama işlemi gerçekleştirebilmektedir. <b>agreedDeliveryDateExtendible</b> true döndüğü durumda bu servis kullanılabilecektir. False iken istek atıldığı durumda tarafınıza hata dönecektir.
        /// </summary>
        /// <param name="extendedDayCount"></param>
        /// <param name="shipmentPackageId"></param>
        /// <returns>HTTP Status Code</returns>
        public async Task<RootResponseModel<object>> AgreedDeliveryDateExtendible(int extendedDayCount, string shipmentPackageId)
        {
            return await Task.Run(() => Client.PutAsync<object>(new AgreedDeliveryDateExtendibleRequest(extendedDayCount), $"/sapigw/suppliers/{SupplierId}/shipment-packages/{shipmentPackageId}/extended-agreed-delivery-date"));
        }
    }
}
