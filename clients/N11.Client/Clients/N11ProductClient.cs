using AutoMapper;
using N11.Client.Services.ProductService;
using N11.Client.Utilities;

namespace N11.Client
{
    public class N11ProductClient
    {
        private readonly ProductServicePortClient _client;
        private readonly ServiceExecutor _serviceExecutor;
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
            _serviceExecutor = new ServiceExecutor();
        }

        public async Task<BaseClientResponse<Product>> GetProductById(long productId)
        {
            var request = new GetProductByProductIdRequest()
            {
                auth = _auth,
                productId = productId
            };

            var response = await _serviceExecutor.ExecuteAsync<Product, GetProductByProductIdResponse>(async () =>
            {
                var result = await _client.GetProductByProductIdAsync(request);
                return result.GetProductByProductIdResponse;
            });

            response.ClientResponse.Data = response.ApiResponse.product;
            return response.ClientResponse;
        }

        public async Task<BaseClientResponse<Product>> GetProductBySellerCode(string sellerCode)
        {
            var request = new GetProductBySellerCodeRequest()
            {
                auth = _auth,
                sellerCode = sellerCode
            };

            var response = await _serviceExecutor.ExecuteAsync<Product, GetProductBySellerCodeResponse>(async () =>
            {
                var result = await _client.GetProductBySellerCodeAsync(request);
                return result.GetProductBySellerCodeResponse;
            });

            response.ClientResponse.Data = response.ApiResponse.product;
            return response.ClientResponse;
        }

        public async Task<BaseClientResponse<ProductBasic[]>> GetProducts()
        {
            var request = new GetProductListRequest()
            {
                auth = _auth
            };

            var response = await _serviceExecutor.ExecuteAsync<ProductBasic[], GetProductListResponse>(async () =>
            {
                var result = await _client.GetProductListAsync(request);
                return result.GetProductListResponse;
            });

            response.ClientResponse.Data = response.ApiResponse.products;
            return response.ClientResponse;
        }
    }
}
