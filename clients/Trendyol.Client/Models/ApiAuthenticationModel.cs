using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trendyol.Client
{
    public class ApiAuthenticationModel
    {
        public string SellerId { get; set; }
        public string ApiKey { get; set; }
        public string ApiSecretKey { get; set; }
        public string Authorization { get; set; }

        public ApiAuthenticationModel()
        {

        }
        public ApiAuthenticationModel CreateAuthentication(AuthenticationType type, string apiKey = "", string apiSecretKey = "", string token = "", string sellerId = "")
        {
            switch (type)
            {
                case AuthenticationType.Basic:
                    string auth = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{apiKey}:{apiSecretKey}"));
                    return new ApiAuthenticationModel()
                    {
                        ApiKey = apiKey,
                        ApiSecretKey = apiSecretKey,
                        SellerId = sellerId,
                        Authorization = $"Basic {auth}"
                    };
                case AuthenticationType.Token:
                    return new ApiAuthenticationModel()
                    {
                        SellerId = sellerId,
                        Authorization = token
                    };
                default:
                    return new ApiAuthenticationModel();
            }
        }
    }

    public enum AuthenticationType
    {
        Basic,
        Token
    }
}
