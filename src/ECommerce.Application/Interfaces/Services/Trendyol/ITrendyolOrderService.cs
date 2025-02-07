using ECommerce.Core.Application;
using ECommerce.Trendyol.Order;
using Trendyol.Client;

namespace ECommerce.Trendyol;

public interface ITrendyolOrderService
{
    Task<IDataResult<GetOrdersResponseModel>> GetOrdersAsync(OrderQueryParametersModelDto parameters);
    Task<IDataResult> UpdateOrderPackageAsync(UpdatePackageRequestDto requestDto, string packageId);
    Task<IDataResult> SetFailureOrderPackageAsync(FailureToSupplyReuqestDto requestDto, string packageId);
}
