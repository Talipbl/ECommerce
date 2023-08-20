using ECommerceNetCore.Application.Results;
using Marketplace.Trendyol;

namespace ECommerceNetCore.Application.Interfaces
{
    public interface ITrendyolService
    {
        Task<IDataResult<GetProductsResponseModel>> GetProducts(int page = 0, int size = 0,
            QueryBooleanOption isApproved = QueryBooleanOption.All,
            QueryBooleanOption isArchived = QueryBooleanOption.All,
            QueryBooleanOption isOnSale = QueryBooleanOption.All,
            QueryBooleanOption isRejected = QueryBooleanOption.All,
            QueryBooleanOption isBlacklisted = QueryBooleanOption.All,
            DateType dateType = DateType.CREATED_DATE,
            DateTime startDate = default, DateTime endDate = default,
            string barcode = "", string stockCode = "", string productMainId = "", string[]? brandIds = default);
        Task<IDataResult<BatchRequestResultModel, ErrorResultModel>> CreateProducts(List<ProductModel> products);

    }
}
