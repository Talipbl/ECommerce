using N11.Client.Services.ProductService;
using System.ServiceModel;

namespace N11.Client
{
    public class BaseClient<TClient, TChannel>
                    where TClient : ClientBase<TChannel>
                    where TChannel : class
    {
        private readonly TClient _client;

        public BaseClient(Uri serviceUrl)
        {
            if (serviceUrl == null)
                throw new ArgumentNullException(nameof(serviceUrl));

            var endpoint = new EndpointAddress(serviceUrl);

            var binding = new BasicHttpBinding
            {
                SendTimeout = TimeSpan.FromSeconds(30),
                ReceiveTimeout = TimeSpan.FromSeconds(30),
                MaxReceivedMessageSize = 65536,
                Security = new BasicHttpSecurity
                {
                    Mode = BasicHttpSecurityMode.Transport
                }
            };

            try
            {
                _client = (TClient)Activator.CreateInstance(typeof(TClient), binding, endpoint);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to create client of type {typeof(TClient).Name}. Details: {ex.Message}", ex);
            }
        }

        public TClient GetClient() => _client;
    }
}
