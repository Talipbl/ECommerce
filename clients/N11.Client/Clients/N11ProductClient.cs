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

        private readonly Uri URL = new("https://api.n11.com/ws/ProductService.wsdl");

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

        public async Task<ClientResponse<Product>> GetProductById(long productId)
        {
            GetProductByProductIdRequest request = new()
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

        public async Task<ClientResponse<Product>> GetProductBySellerCode(string sellerCode)
        {
            GetProductBySellerCodeRequest request = new()
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

        public async Task<ClientResponse<ProductBasic[]>> GetProductList(int currentPage = 0, int pageSize = 100)
        {
            GetProductListRequest request = new()
            {
                auth = _auth,
                pagingData = new()
                {
                    currentPage = currentPage,
                    pageSize = pageSize,
                }
            };

            var response = await _serviceExecutor.ExecuteAsync<ProductBasic[], GetProductListResponse>(async () =>
            {
                var result = await _client.GetProductListAsync(request);
                return result.GetProductListResponse;
            });

            response.ClientResponse.Data = response.ApiResponse.products;
            return response.ClientResponse;
        }

        public async Task<ClientResponse<ProductBasic>> CreateAndUpdateProduct(ProductRequest product)
        {
            SaveProductRequest request = new()
            {
                auth = _auth,
                product = product
            };

            var response = await _serviceExecutor.ExecuteAsync<ProductBasic, SaveProductResponse>(async () =>
            {
                var result = await _client.SaveProductAsync(request);
                return result.SaveProductResponse;
            });

            response.ClientResponse.Data = response.ApiResponse.product;
            return response.ClientResponse;
        }

        public async Task<ClientResponse<ProductBasic[]>> SearchProducts(ProductSearch search, int currentPage = 0, int pageSize = 100)
        {
            SearchProductsRequest request = new()
            {
                auth = _auth,
                productSearch = search,
                pagingData = new()
                {
                    currentPage = currentPage,
                    pageSize = pageSize
                }
            };

            var response = await _serviceExecutor.ExecuteAsync<ProductBasic[], SearchProductsResponse>(async () =>
            {
                var result = await _client.SearchProductsAsync(request);
                return result.SearchProductsResponse;
            });

            response.ClientResponse.Data = response.ApiResponse.products;
            return response.ClientResponse;
        }

        public async Task<ClientResponse<ProductBasic>> DeleteProductById(int productId)
        {
            DeleteProductByIdRequest request = new()
            {
                auth = _auth,
                productId = productId
            };

            var response = await _serviceExecutor.ExecuteAsync<ProductBasic, DeleteProductByIdResponse>(async () =>
            {
                var result = await _client.DeleteProductByIdAsync(request);
                return result.DeleteProductByIdResponse;
            });

            response.ClientResponse.Data = response.ApiResponse.product;
            return response.ClientResponse;
        }

        public async Task<ClientResponse<ProductBasic>> DeleteProductByStockCode(string stockCode)
        {
            DeleteProductBySellerCodeRequest request = new()
            {
                auth = _auth,
                productSellerCode = stockCode
            };

            var response = await _serviceExecutor.ExecuteAsync<ProductBasic, DeleteProductBySellerCodeResponse>(async () =>
            {
                var result = await _client.DeleteProductBySellerCodeAsync(request);
                return result.DeleteProductBySellerCodeResponse;
            });

            response.ClientResponse.Data = response.ApiResponse.product;
            return response.ClientResponse;
        }

        public async Task<ClientResponse<ProductQuestion[]>> GetProductQuestionList(ProductQuestionSearch questionSearch, int currentPage = 0, int pageSize = 100)
        {
            GetProductQuestionListRequest request = new()
            {
                auth = _auth,
                productQuestionSearch = questionSearch,
                pagingData = new()
                {
                    currentPage = currentPage,
                    pageSize = pageSize
                }
            };

            var response = await _serviceExecutor.ExecuteAsync<ProductQuestion[], GetProductQuestionListResponse>(async () =>
            {
                var result = await _client.GetProductQuestionListAsync(request);
                return result.GetProductQuestionListResponse;
            });

            response.ClientResponse.Data = response.ApiResponse.productQuestions;
            return response.ClientResponse;
        }

        public async Task<ClientResponse<ProductQuestionDetail>> GetProductQuestionDetail(int questionId)
        {
            GetProductQuestionDetailRequest request = new()
            {
                auth = _auth,
                productQuestionId = questionId
            };

            var response = await _serviceExecutor.ExecuteAsync<ProductQuestionDetail, GetProductQuestionDetailResponse>(async () =>
            {
                var result = await _client.GetProductQuestionDetailAsync(request);
                return result.GetProductQuestionDetailResponse;
            });

            response.ClientResponse.Data = response.ApiResponse.productQuestion;
            return response.ClientResponse;
        }

        public async Task<BaseClientResponse> SaveProductAnswer(int questionId, string answer)
        {
            SaveProductAnswerRequest request = new()
            {
                auth = _auth,
                productQuestionId = questionId,
                answer = answer
            };

            var response = await _serviceExecutor.ExecuteAsync(async () =>
            {
                var result = await _client.SaveProductAnswerAsync(request);
                return result.SaveProductAnswerResponse;
            });

            return response.ClientResponse;
        }

        public async Task<ClientResponse<ProductApprovalStatusApi>> GetProductAllStatusCounts()
        {
            try
            {
                var request = new ProductApprovalStatusRequest() { auth = _auth };
                var result = await _client.ProductApprovalStatusAsync(request);
                return new ClientResponse<ProductApprovalStatusApi>() { Data = result.ProductApprovalStatusResponse1.result, Status = true };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
