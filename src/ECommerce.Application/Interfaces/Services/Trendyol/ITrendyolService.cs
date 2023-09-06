using ECommerce.Core.Application;
using Marketplaces.Trendyol;

namespace ECommerce.Trendyol;

public interface ITrendyolService
{
    Task<IDataResult<TrendyolWebSearchResultDto>> SearchCrawlerProducts(string url, int page = 1);
    Task<IDataResult<TrendyolCrawlerProductDetailDto>> GetCrawlerProductDetail(int productId);
    Task<IDataResult<GetProductsResponseModel>> GetProducts(int page = 0, int size = 0,
        QueryBooleanOption isApproved = QueryBooleanOption.All,
        QueryBooleanOption isArchived = QueryBooleanOption.All,
        QueryBooleanOption isOnSale = QueryBooleanOption.All,
        QueryBooleanOption isRejected = QueryBooleanOption.All,
        QueryBooleanOption isBlacklisted = QueryBooleanOption.All,
        DateType dateType = DateType.CREATED_DATE,
        DateTime startDate = default, DateTime endDate = default,
        string barcode = "", string stockCode = "", string productMainId = "", string[]? brandIds = default);
    Task<IDataResult<TrendyolBatchRequestResultDto, TrendyolErrorResultDto>> CreateCopyProduct(int[] ids);

}
