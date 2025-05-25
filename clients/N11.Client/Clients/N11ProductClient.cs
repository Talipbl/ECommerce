using N11.Client.Models.Response;
using N11.Client.Services.ProductService;
using N11.Client.Utilities;

namespace N11.Client
{
    public class N11ProductClient
    {
        private readonly ProductServicePortClient _client;
        private readonly BaseHttpClient _httpClient;
        private readonly ServiceExecutor _serviceExecutor;
        private readonly Authentication _auth;
        private readonly ApiAuthentication _apiAuth;

        private readonly Uri Url = new("https://api.n11.com/ws/ProductService.wsdl");
        private const string RestUrl = "https://api.n11.com";
        private const string Prefix = "/ms/product";


        public N11ProductClient(string appKey, string appSecretKey)
        {
            _auth = new()
            {
                appKey = appKey,
                appSecret = appSecretKey
            };
            _apiAuth = new()
            {
                AppKey = appKey,
                AppSecretKey = appSecretKey,
                IntegratorName = "SelfIntegration",
            };

            _client = new BaseClient<ProductServicePortClient, ProductServicePort>(Url).GetClient();
            _httpClient = new BaseHttpClient(RestUrl, _apiAuth);
            _serviceExecutor = new ServiceExecutor();
        }

        public async Task<BaseResponse<RestResponse>> CreateProductAsync(List<StockItem> skus)
        {
            var createRequest = new ProductRequest
            {
                Payload = new Payload
                {
                    Integrator = _apiAuth.IntegratorName,
                    Skus = skus
                }
            };
            return await _httpClient.PostAsync<RestResponse>(createRequest, $"{Prefix}/tasks/product-create");
        }

        public async Task<BaseResponse<RestResponse>> UpdateProductAsync(List<StockItem> skus)
        {
            var updateRequest = new ProductRequest
            {
                Payload = new Payload
                {
                    Integrator = _apiAuth.IntegratorName,
                    Skus = skus
                }
            };
            return await _httpClient.PostAsync<RestResponse>(updateRequest, $"{Prefix}/tasks/product-update");
        }

        public async Task<BaseResponse<RestResponse>> UpdateProductPriceAndStockAsync(List<StockItem> skus)
        {
            var skuRequest = new StockUpdateRequest
            {
                Payload = new Payload()
                {
                    Integrator = _apiAuth.IntegratorName,
                    Skus = skus
                }
            };
            return await _httpClient.PostAsync<RestResponse>(skuRequest, $"{Prefix}/tasks/price-stock-update");
        }

        public async Task<BaseResponse<TaskDetailsResponse>> TaskDetailAsync(int taskId)
        {
            var detailRequest = new TaskDetailsRequest
            {
                TaskId = taskId,
                Pageable = new Pagination
                {
                    Page = 0,
                    Size = 100
                },
            };
            return await _httpClient.PostAsync<TaskDetailsResponse>(detailRequest, $"{Prefix}/task-details/page-query");
        }

        public async Task<BaseResponse<ProductQueryResponse>> GetProductQueryAsync(ProductQueryParameter queries)
        {
            string queryString = JsonHelper.BuildQueryString(queries);
            return await _httpClient.GetAsync<ProductQueryResponse>($"/ms/product-query?{queryString}");
        }

        public async Task<ClientResponse<Services.ProductService.Product>> GetProductByIdAsync(int productId)
        {
            GetProductByProductIdRequest request = new()
            {
                auth = _auth,
                productId = productId
            };

            var response = await _serviceExecutor.ExecuteAsync<Services.ProductService.Product, GetProductByProductIdResponse>(async () =>
            {
                var result = await _client.GetProductByProductIdAsync(request);
                return result.GetProductByProductIdResponse;
            });

            response.ClientResponse.Data = response.ApiResponse.product;
            return response.ClientResponse;
        }

        public async Task<ClientResponse<Services.ProductService.Product>> GetProductBySellerCodeAsync(string sellerCode)
        {
            GetProductBySellerCodeRequest request = new()
            {
                auth = _auth,
                sellerCode = sellerCode
            };

            var response = await _serviceExecutor.ExecuteAsync<Services.ProductService.Product, GetProductBySellerCodeResponse>(async () =>
            {
                var result = await _client.GetProductBySellerCodeAsync(request);
                return result.GetProductBySellerCodeResponse;
            });

            response.ClientResponse.Data = response.ApiResponse.product;
            return response.ClientResponse;
        }

        public async Task<ClientResponse<Services.ProductService.ProductBasic[]>> GetProductListAsync(int currentPage = 0, int pageSize = 100)
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

            var response = await _serviceExecutor.ExecuteAsync<Services.ProductService.ProductBasic[], GetProductListResponse>(async () =>
            {
                var result = await _client.GetProductListAsync(request);
                return result.GetProductListResponse;
            });

            response.ClientResponse.Data = response.ApiResponse.products;
            return response.ClientResponse;
        }

        public async Task<ClientResponse<Services.ProductService.ProductBasic>> CreateAndUpdateProductAsync(Services.ProductService.ProductRequest product)
        {
            SaveProductRequest request = new()
            {
                auth = _auth,
                product = product
            };

            var response = await _serviceExecutor.ExecuteAsync<Services.ProductService.ProductBasic, SaveProductResponse>(async () =>
            {
                var result = await _client.SaveProductAsync(request);
                return result.SaveProductResponse;
            });

            response.ClientResponse.Data = response.ApiResponse.product;
            return response.ClientResponse;
        }

        public async Task<ClientResponse<Services.ProductService.ProductBasic[]>> SearchProductsAsync(ProductSearch search, int currentPage = 0, int pageSize = 100)
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

            var response = await _serviceExecutor.ExecuteAsync<Services.ProductService.ProductBasic[], SearchProductsResponse>(async () =>
            {
                var result = await _client.SearchProductsAsync(request);
                return result.SearchProductsResponse;
            });

            response.ClientResponse.Data = response.ApiResponse.products;
            return response.ClientResponse;
        }

        public async Task<ClientResponse<Services.ProductService.ProductBasic>> DeleteProductByIdAsync(int productId)
        {
            DeleteProductByIdRequest request = new()
            {
                auth = _auth,
                productId = productId
            };

            var response = await _serviceExecutor.ExecuteAsync<Services.ProductService.ProductBasic, DeleteProductByIdResponse>(async () =>
            {
                var result = await _client.DeleteProductByIdAsync(request);
                return result.DeleteProductByIdResponse;
            });

            response.ClientResponse.Data = response.ApiResponse.product;
            return response.ClientResponse;
        }

        public async Task<ClientResponse<Services.ProductService.ProductBasic>> DeleteProductByStockCodeAsync(string stockCode)
        {
            DeleteProductBySellerCodeRequest request = new()
            {
                auth = _auth,
                productSellerCode = stockCode
            };

            var response = await _serviceExecutor.ExecuteAsync<Services.ProductService.ProductBasic, DeleteProductBySellerCodeResponse>(async () =>
            {
                var result = await _client.DeleteProductBySellerCodeAsync(request);
                return result.DeleteProductBySellerCodeResponse;
            });

            response.ClientResponse.Data = response.ApiResponse.product;
            return response.ClientResponse;
        }

        public async Task<ClientResponse<ProductQuestion[]>> GetProductQuestionListAsync(ProductQuestionSearch questionSearch, int currentPage = 0, int pageSize = 100)
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

        public async Task<ClientResponse<ProductQuestionDetail>> GetProductQuestionDetailAsync(int questionId)
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

        public async Task<BaseClientResponse> SaveProductAnswerAsync(int questionId, string answer)
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

        public async Task<ClientResponse<ProductApprovalStatusApi>> GetProductAllStatusCountsAsync()
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
