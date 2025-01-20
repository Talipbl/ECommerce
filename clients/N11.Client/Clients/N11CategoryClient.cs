using N11.Client.Services.CategoryService;
using N11.Client.Utilities;

namespace N11.Client
{
    public class N11CategoryClient
    {
        private readonly CategoryServicePortClient _client;
        private readonly ServiceExecutor _serviceExecutor;
        private readonly Authentication _auth;

        private readonly Uri URL = new("https://api.n11.com/ws/CategoryService.wsdl");

        public N11CategoryClient(string appKey, string appSecretKey)
        {
            _auth = new()
            {
                appKey = appKey,
                appSecret = appSecretKey
            };

            _client = new BaseClient<CategoryServicePortClient, CategoryServicePort>(URL).GetClient();
            _serviceExecutor = new ServiceExecutor();
        }

        public async Task<ClientResponse<CategoryData>> GetCategoryAttributes(int categoryId, int currentPage = 0, int pageSize = 100)
        {
            GetCategoryAttributesRequest request = new()
            {
                auth = _auth,
                categoryId = categoryId,
                pagingData = new()
                {
                    currentPage = currentPage,
                    pageSize = pageSize
                }
            };

            var response = await _serviceExecutor.ExecuteAsync<CategoryData, GetCategoryAttributesResponse>(async () =>
            {
                var result = await _client.GetCategoryAttributesAsync(request);
                return result.GetCategoryAttributesResponse;
            });

            response.ClientResponse.Data = response.ApiResponse.category;
            return response.ClientResponse;
        }

        public async Task<ClientResponse<CategoryProductAttributeData[]>> GetCategoryAttributesId(int categoryId)
        {
            GetCategoryAttributesIdRequest request = new()
            {
                auth = _auth,
                categoryId = categoryId
            };

            var response = await _serviceExecutor.ExecuteAsync<CategoryProductAttributeData[], GetCategoryAttributesIdResponse>(async () =>
            {
                var result = await _client.GetCategoryAttributesIdAsync(request);
                return result.GetCategoryAttributesIdResponse;
            });

            response.ClientResponse.Data = response.ApiResponse.categoryProductAttributeList;
            return response.ClientResponse;
        }

        public async Task<ClientResponse<CategoryProductAttributeValueData[]>> GetCategoryAttributeValue(int categoryId, int productAttributeId, int currentPage, int pageSize)
        {
            GetCategoryAttributeValueRequest request = new()
            {
                auth = _auth,
                categoryId = categoryId,
                categoryProductAttributeId = productAttributeId,
                pagingData = new()
                {
                    currentPage = currentPage,
                    pageSize = pageSize 
                }
            };

            var response = await _serviceExecutor.ExecuteAsync<CategoryProductAttributeValueData[], GetCategoryAttributeValueResponse>(async () =>
            {
                var result = await _client.GetCategoryAttributeValueAsync(request);
                return result.GetCategoryAttributeValueResponse;
            });

            response.ClientResponse.Data = response.ApiResponse.categoryProductAttributeValueList;
            return response.ClientResponse;
        }

        public async Task<ClientResponse<ParentCategoryData>> GetParentCategory(int categoryId)
        {
            GetParentCategoryRequest request = new()
            {
                auth = _auth,
                categoryId = categoryId
            };

            var response = await _serviceExecutor.ExecuteAsync<ParentCategoryData, GetParentCategoryResponse>(async () =>
            {
                var result = await _client.GetParentCategoryAsync(request);
                return result.GetParentCategoryResponse;
            });

            response.ClientResponse.Data = response.ApiResponse.category;
            return response.ClientResponse;
        }

        public async Task<ClientResponse<SubCategoryData[]>> GetSubCategories(int categoryId)
        {
            GetSubCategoriesRequest request = new()
            {
                auth = _auth,
                categoryId = categoryId
            };

            var response = await _serviceExecutor.ExecuteAsync<SubCategoryData[], GetSubCategoriesResponse>(async () =>
            {
                var result = await _client.GetSubCategoriesAsync(request);
                return result.GetSubCategoriesResponse;
            });

            response.ClientResponse.Data = response.ApiResponse.category;
            return response.ClientResponse;
        }

        public async Task<ClientResponse<SubCategory[]>> GetTopLevelCategories()
        {
            GetTopLevelCategoriesRequest request = new()
            {
                auth = _auth
            };

            var response = await _serviceExecutor.ExecuteAsync<SubCategory[], GetTopLevelCategoriesResponse>(async () =>
            {
                var result = await _client.GetTopLevelCategoriesAsync(request);
                return result.GetTopLevelCategoriesResponse;
            });

            response.ClientResponse.Data = response.ApiResponse.categoryList;
            return response.ClientResponse;
        }
    }
}
