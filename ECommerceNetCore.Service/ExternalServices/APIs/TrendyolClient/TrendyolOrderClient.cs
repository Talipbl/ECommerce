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

            Client = new TrendyolHttpClient("https://api.trendyol.com/sapigw", SupplierId, authorization);
        }
        public async Task<HttpResponseModel<GetOrdersResponseModel>> GetOrders(OrderQueryParametersModel queries)
        {
            string queryString = JsonHelper.BuildQueryString(queries);
            return await Task.Run(() => Client.GetAsync<GetOrdersResponseModel>($"/suppliers/{SupplierId}/orders?{queryString}"));
        }
        public async Task<HttpResponseModel<object>> UpdateTrackingNumber(string shipmentPackageId)
        {
            return await Task.Run(() => Client.PutAsync<object>(new TrackingNumberModel(shipmentPackageId),$"/suppliers/{SupplierId}/{shipmentPackageId}/update-tracking-number"));
        }
    }
}
