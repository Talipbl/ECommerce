using ECommerce.Core.Application;
using ECommerce.Trendyol.Order;
using Microsoft.Extensions.Options;
using Trendyol.Client;

namespace ECommerce.Trendyol
{
    public class TrendyolOrderService(ITrendyolOrderAdapter _adapter, IOptions<TrendyolOptions> options) : ITrendyolOrderService
    {
        private readonly TrendyolOrderClient _orderClient = new(options.Value.ToAuthentication());

        public async Task<IDataResult<GetOrdersResponseDTO>> GetOrdersAsync(OrderQueryParametersModelDTO parameters)
        {
            OrderQueryParametersModel model = _adapter.Adapt<OrderQueryParametersModel>(parameters);
            var result = await _orderClient.GetOrders(model);
            var responseDto = _adapter.Adapt<GetOrdersResponseDTO>(result.OkResponse);
            return new DataResult<GetOrdersResponseDTO>(responseDto, result.IsSuccess);
        }

        public async Task<IDataResult> SetFailureOrderPackageAsync(FailureToSupplyReuqestDTO requestDto, string packageId)
        {
            FailureToSupplyReuqest request = _adapter.AdaptFailureRequest(requestDto);
            var result = await _orderClient.SetFailureToSupply(request, packageId);

            return new DataResult(result.IsSuccess);
        }

        public async Task<IDataResult> PickingOrderPackageAsync(UpdatePackageRequestDTO requestDto, string packageId)
        {
            UpdatePackageRequest request = _adapter.AdaptUpdateRequest(requestDto);
            var result = await _orderClient.UpdatePackage(request, packageId);

            return new DataResult(result.IsSuccess);
        }
    }
}
