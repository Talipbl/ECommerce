using ECommerce.Core.Application;
using ECommerce.Trendyol.Order;
using Trendyol.Client;

namespace ECommerce.Trendyol
{
    public class TrendyolOrderService(ITrendyolOrderAdapter adapter, TrendyolOrderClient orderClient) : ITrendyolOrderService
    {
        public async Task<IDataResult<GetOrdersResponseDTO>> GetOrdersAsync(OrderQueryParametersModelDTO parameters)
        {
            var result = await orderClient.GetOrders(adapter.Adapt<OrderQueryParametersModel>(parameters));
            var responseDto = adapter.Adapt<GetOrdersResponseDTO>(result.OkResponse);
            return new DataResult<GetOrdersResponseDTO>(responseDto, result.IsSuccess);
        }

        public async Task<IDataResult> SetFailureOrderPackageAsync(FailureToSupplyReuqestDTO requestDto, string packageId)
        {
            var result = await orderClient.SetFailureToSupply(adapter.AdaptFailureRequest(requestDto), packageId);
            return new DataResult(result.IsSuccess);
        }

        public async Task<IDataResult> PickingOrderPackageAsync(UpdatePackageRequestDTO requestDto, string packageId)
        {
            var result = await orderClient.UpdatePackage(adapter.AdaptUpdateRequest(requestDto), packageId);
            return new DataResult(result.IsSuccess);
        }
    }
}
