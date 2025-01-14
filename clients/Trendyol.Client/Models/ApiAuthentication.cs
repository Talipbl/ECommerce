using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trendyol.Client
{
    public class ApiAuthentication
    {
        public string SellerId { get; set; }
        public string ApiKey { get; set; }
        public string ApiSecretKey { get; set; }
        public string Authorization { get; set; }

        public static ApiAuthentication CreateAuthentication(string apiKey = "", string apiSecretKey = "", string sellerId = "")
        {
            string auth = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{apiKey}:{apiSecretKey}"));
            return new ApiAuthentication()
            {
                ApiKey = apiKey,
                ApiSecretKey = apiSecretKey,
                SellerId = sellerId,
                Authorization = $"Basic {auth}"
            };
        }

        public static ApiAuthentication CreateAuthentication(string token, string sellerId)
        {
            return new ApiAuthentication()
            {
                SellerId = sellerId,
                Authorization = token
            };
        }
    }

    public enum AuthenticationType
    {
        Basic,
        Token
    }
}
