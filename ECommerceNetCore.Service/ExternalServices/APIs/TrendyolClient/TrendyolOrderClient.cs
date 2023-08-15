using ECommerceNetCore.Application.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ECommerceNetCore.Service.Models;
using Microsoft.AspNetCore.Http;
using Azure.Core;
using ECommerceNetCore.Service.ExternalServices.APIs.TrendyolClient.Models.OrderModels;

namespace ECommerceNetCore.Service.ExternalServices.APIs.TrendyolClient
{
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
        public async Task<HttpResponseModel<GetOrdersResponseModel>> GetOrders(OrderQueryParametersModel queries)
        {
            string queryString = JsonHelper.BuildQueryString(queries);
            return await Task.Run(() => Client.GetAsync<GetOrdersResponseModel>($"/sapigw/suppliers/{SupplierId}/orders?{queryString}"));
        }
        public async Task<HttpResponseModel<object>> UpdateTrackingNumber(string shipmentPackageId)
        {
            return await Task.Run(() => Client.PutAsync<object>(new TrackingNumberModel(shipmentPackageId), $"/sapigw/suppliers/{SupplierId}/{shipmentPackageId}/update-tracking-number"));
        }
        public async Task<HttpResponseModel<object>> UpdatePackage(UpdatePackageRequest request, string shipmentPackageId)
        {
            //Non-Procurement Notice eklenecek
            return await Task.Run(()=>Client.PutAsync<object>(new UpdatePackageRequest(request), $"/sapigw/suppliers/{SupplierId}/shipment-packages/{shipmentPackageId}"));
        }
        /// <summary>
        /// Tedarik edememe bildirimi yapıldıktan sonra Trendyol Order Management System tarafından 
        /// aynı orderNumber üzerinde yeni bir 
        /// ShipmentPackageID oluşturulmakta ve daha önceki shipmentpackage iptal edilmektedir. 
        /// Bu durumda Tedarik Edememe kaydı yapıldıktan sonra tekrar Sipariş Paketlerini Çekme işlemi 
        /// yapılması gerekmektedir.
        /// prod https://api.trendyol.com/integration/oms/core/sellers/{sellerId}/shipment-packages/{shipmentPackageId}/items/unsupplied
        /// stage https://stageapi.trendyol.com/integration/oms/core/sellers/{sellerId}/shipment-packages/{shipmentPackageId}/items/unsupplied
        /// </summary>
        /// <param name="request"></param>
        /// <param name="shipmentPackageId"></param>
        /// <param name="sellerId"></param>
        /// <returns>model, string, string</returns>
        public async Task<HttpResponseModel<object>> UpdatePackage(NonProcurementNoticeReuqest request, string shipmentPackageId,string sellerId)
        {

            return await Task.Run(()=>Client.PutAsync<object>(new NonProcurementNoticeReuqest(request), $"/integration/oms/core/sellers/{sellerId}/shipment-packages/{shipmentPackageId}/items/unsupplied"));
        }

        public async Task<HttpResponseModel<string>> SendInvoiceLink(SendInvoiceLinkReuqest request)
        {
            return await Task.Run(() => Client.PutAsync<string>(new SendInvoiceLinkReuqest(request), $"/sapigw/suppliers/{SupplierId}/supplier-invoice-links"));
        }
        //bakılacak.
        public async Task<HttpResponseModel<object>> SplitShipmentPackage(SplitShipmentPackageQuantityRequest request, string shipmentPackageId)
        {
            return await Task.Run(() => Client.PostAsync<object>(new SplitShipmentPackageQuantityRequest(request), $"/sapigw/suppliers/{SupplierId}/shipment-packages/{shipmentPackageId}/split-packages"));
        }
        public async Task<HttpResponseModel<object>> SplitShipmentPackage(string orderLineIds, string shipmentPackageId)
        {
            return await Task.Run(() => Client.PostAsync<object>(orderLineIds, $"/sapigw/suppliers/{SupplierId}/shipment-packages/{shipmentPackageId}/split"));
        }
        public async Task<HttpResponseModel<object>> SplitShipmentPackage(SplitShipmentPackageMultiSplintRequest request, string shipmentPackageId)
        {
            return await Task.Run(() => Client.PostAsync<object>(new SplitShipmentPackageMultiSplintRequest(request), $"/sapigw/suppliers/{SupplierId}/shipment-packages/{shipmentPackageId}/multi-split"));
        }
        public async Task<HttpResponseModel<object>> SplitShipmentPackage(SplitShipmentPackageByQuantityRequest request, string shipmentPackageId)
        {
            return await Task.Run(() => Client.PostAsync<object>(new SplitShipmentPackageByQuantityRequest(request), $"/sapigw/suppliers/{SupplierId}/shipment-packages/{shipmentPackageId}/quantity-split"));
        }
        public async Task<HttpResponseModel<object>> updateBoxInfo(UpdateBoxInfoRequest request, string shipmentPackageId) {
            return await Task.Run(() => Client.PostAsync<object>(new UpdateBoxInfoRequest(request), $"/sapigw/suppliers/{SupplierId}/shipment-packages/{shipmentPackageId}/box-info"));
        }
        public async Task<HttpResponseModel<object>> ProcessAlternativeDelivery() { 
            return null;
        }
        //shipment-packages/{Id}/delivered-by-service stage  stage https://stageapi.trendyol.com/integration/oms/core/sellers/{sellerId}/shipment-packages/{packageId}/delivered-by-service
        public async Task<HttpResponseModel<object>> DeliveredByService(string shipmentPackageId) {
            return await Task.Run(() => Client.PutAsync<object>(null,$"/sapigw/suppliers/{SupplierId}/shipment-packages/{shipmentPackageId}/delivered-by-service stage"));
        }
        /// <summary>
        /// Bu işlem bir paket için 5 dakika içerisinde yalnızca 1 kere yapılabilir.
        /// Kargo değişiminden sonra ilgili paketi sipariş servisimizden tekrar çekerek kontrol etmeniz gerekmektedir.
        /// Kargo firması TEX olarak gönderilen güncelleme istekleri satıcının TEX kotasının dolduğu durumlarda geçersiz olacaktır.
        /// </summary>
        /// <param name="cargoProvider"></param>
        ///“YKMP”
        ///“ARASMP”
        ///“SURATMP”
        ///“HOROZMP”
        ///“MNGMP”
        ///“PTTMP”
        ///“CEVAMP”
        ///“TEXMP”
        ///"UPSMP"
        ///"SENDEOMP"
        /// <returns></returns>
        public async Task<HttpResponseModel<object>> ChangeCargoProvider(string cargoProvider, string shipmentPackageId) {
            return await Task.Run(() => Client.PutAsync<object>(cargoProvider, $"/sapigw/suppliers/{SupplierId}/shipment-packages/{shipmentPackageId}/cargo-providers"));
        }
        /// <summary>
        /// Eğer sevkiyat adresi eklenmesi isteniyor ise satıcı paneli üzerinden ekleme yapılabilmektedir.
        /// prod https://api.trendyol.com/sapigw/suppliers/{supplierId}/shipment-packages/{packageId}/warehouse
        /// stage https://stageapi.trendyol.com/integration/oms/core/sellers/{sellerId}/shipment-packages/{packageId}/warehouse
        /// </summary>
        /// <param name="warehouseId"></param>
        /// <param name="shipmentPackageId"></param>
        /// <param name="packageId"></param>
        /// <returns>int</returns>
        public async Task<HttpResponseModel<string>> updateWarehouse(string warehouseId, string shipmentPackageId, string packageId) {
            return await Task.Run(() => Client.PutAsync<string>(warehouseId, $"/sapigw/suppliers/{SupplierId}/shipment-packages/{shipmentPackageId}/shipment-packages/{packageId}/warehouse"));
        }
        /// <summary>
        /// prod https://api.trendyol.com/sapigw/suppliers/{supplierId}/shipment-packages/{Id}/extended-agreed-delivery-date
        /// stage https://stageapi.trendyol.com/integration/oms/core/sellers/{sellerId}/shipment-packages/{packageId}/extended-agreed-delivery-date
        /// 
        /// </summary>
        /// <param name="extendedDayCount"></param>
        /// <param name="shipmentPackageId"></param>
        /// <returns></returns>
        public async Task<HttpResponseModel<object>> AgreedDeliveryDateExtendible(int extendedDayCount, string shipmentPackageId) {
            return await Task.Run(() => Client.PutAsync<object>(extendedDayCount, $"/sapigw/suppliers/{SupplierId}/shipment-packages/{shipmentPackageId}/extended-agreed-delivery-date"));
        }
    }
}
