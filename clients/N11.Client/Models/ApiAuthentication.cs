using System.Text;

namespace N11.Client
{
    public class ApiAuthentication
    {
        public string IntegratorName { get; set; }
        public string AppKey { get; set; }
        public string AppSecretKey { get; set; }

        public static ApiAuthentication CreateAuthentication(string apiKey = "", string apiSecretKey = "", string integratorName = "")
        {
            return new ApiAuthentication()
            {
                AppKey = apiKey,
                AppSecretKey = apiSecretKey,
                IntegratorName = integratorName
            };
        }
    }
}
