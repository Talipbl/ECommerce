using ECommerceNetCore.Application.Interfaces;
using ECommerceNetCore.Application.Results;
using Marketplace.Trendyol;
using Newtonsoft.Json;

namespace ECommerceNetCore.Application.Services
{
    public class TrendyolService : ITrendyolService
    {
        TrendyolClient _trendyolClient;
        public TrendyolService()
        {
            _trendyolClient = new TrendyolClient();
        }

        public async Task<IDataResult<BatchRequestResultModel, ErrorResultModel>> CreateProducts(List<ProductModel> products)
        {
            var result = await _trendyolClient.CreateProductsAsync(products);
            if (result.IsSuccess)
                return new DataResult<BatchRequestResultModel,ErrorResultModel>(result.AdditionalData, result.IsSuccess);

            var errorReturn = JsonConvert.DeserializeObject<ErrorResultModel>((string)result.ErrorValueReturn);
            return new DataResult<BatchRequestResultModel, ErrorResultModel>(result.AdditionalData, errorReturn, result.IsSuccess);
        }

        public async Task<IDataResult<GetProductsResponseModel>> GetProducts(int page = 0, int size = 0, QueryBooleanOption isApproved = QueryBooleanOption.All, QueryBooleanOption isArchived = QueryBooleanOption.All, QueryBooleanOption isOnSale = QueryBooleanOption.All, QueryBooleanOption isRejected = QueryBooleanOption.All, QueryBooleanOption isBlacklisted = QueryBooleanOption.All, DateType dateType = DateType.CREATED_DATE, DateTime startDate = default, DateTime endDate = default, string barcode = "", string stockCode = "", string productMainId = "", string[]? brandIds = null)
        {
            var result = await _trendyolClient.GetProductsAsync(page, size,isApproved, isArchived, isOnSale, isRejected, isBlacklisted, dateType, startDate, endDate, barcode, stockCode, productMainId, brandIds);

            return new DataResult<GetProductsResponseModel>(result.OkResponse, result.IsSuccess);
        }
    }
}
