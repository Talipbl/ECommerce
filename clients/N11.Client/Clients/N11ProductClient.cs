using N11.Client.Services.ProductService;

namespace N11.Client
{
    public class N11ProductClient
    {
        private readonly ProductServicePortClient _client;
        private readonly Authentication _auth;

        private readonly Uri URL = new("https://api.n11.com/ws/OrderService.wsdl");

        public N11ProductClient(string appKey, string appSecretKey)
        {
            _auth = new()
            {
                appKey = appKey,
                appSecret = appSecretKey
            };

            _client = new BaseClient<ProductServicePortClient, ProductServicePort>(URL).GetClient();
        }

        public async Task GetProductById(int productId)
        {
            var request = new GetProductByProductIdRequest()
            {
                auth = _auth,
                productId = productId
            };

            //Hata ayıklama işlemi burada ele alınacak.
            var response = await _client.GetProductByProductIdAsync(request);
        }
    }
}
