using Ecommerce.Shared.Utilities.Results;
using ECommerce.Trendyol.Order;
using Trendyol.Client;

namespace ECommerce.Trendyol
{
    public class TrendyolOrderService(ITrendyolOrderAdapter _adapter) : ITrendyolOrderService
    {
        TrendyolOrderClient _orderClient = new(ApiAuthentication.CreateAuthentication("atBqHAZm2Eg1ZttXGpMZ", "LSEzaIx17XkuFiYyXyRu", "836049"));

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
