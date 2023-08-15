using ECommerceNetCore.Application.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ECommerceNetCore.Service.Models;

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
    }
}
