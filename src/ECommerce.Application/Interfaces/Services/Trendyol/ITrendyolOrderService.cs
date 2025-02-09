using ECommerce.Core.Application;
using ECommerce.Trendyol.Order;
using Trendyol.Client;

namespace ECommerce.Trendyol;

public interface ITrendyolOrderService
{
    Task<IDataResult<GetOrdersResponseDTO>> GetOrdersAsync(OrderQueryParametersModelDTO parameters);
    Task<IDataResult> PickingOrderPackageAsync(UpdatePackageRequestDTO requestDto, string packageId);
    Task<IDataResult> SetFailureOrderPackageAsync(FailureToSupplyReuqestDTO requestDto, string packageId);
}
