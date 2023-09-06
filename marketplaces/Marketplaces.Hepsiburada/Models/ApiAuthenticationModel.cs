using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Hepsiburada
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
        public ApiAuthenticationModel CreateAuthentication(AuthenticationType type, string apiKey, string apiSecretKey, string token = "", string sellerId = "")
        {
            switch (type)
            {
                case AuthenticationType.Basic:
                    return new ApiAuthenticationModel()
                    {
                        ApiKey = apiKey,
                        ApiSecretKey = apiSecretKey,
                        SellerId = sellerId,
                        Authorization = $"Basic {Convert.ToBase64String(Encoding.ASCII.GetBytes($"{ApiKey}:{ApiSecretKey}"))}"
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
