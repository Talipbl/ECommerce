using System.Text;

namespace Marketplaces.Hepsiburada
{
    public class ApiAuthentication
    {
        public string SellerId { get; set; }
        public string ApiKey { get; set; }
        public string ApiSecretKey { get; set; }
        public string Authorization { get; set; }

        public ApiAuthentication()
        {

        }
        public ApiAuthentication CreateAuthentication(AuthenticationType type, string apiKey = "", string apiSecretKey = "", string token = "", string sellerId = "")
        {
            switch (type)
            {
                case AuthenticationType.Basic:
                    string auth = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{apiKey}:{apiSecretKey}"));
                    return new ApiAuthentication()
                    {
                        ApiKey = apiKey,
                        ApiSecretKey = apiSecretKey,
                        SellerId = sellerId,
                        Authorization = $"Basic {auth}"
                    };
                case AuthenticationType.Token:
                    return new ApiAuthentication()
                    {
                        SellerId = sellerId,
                        Authorization = token
                    };
                default:
                    return new ApiAuthentication();
            }
        }
    }

    public enum AuthenticationType
    {
        Basic,
        Token
    }
}
