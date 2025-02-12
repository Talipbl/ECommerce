using ECommerce.Core.Application;
using ECommerce.Services;
using ECommerce.Trendyol.Order;
using Trendyol.Client;

namespace ECommerce.Trendyol
{
    public class TrendyolOrderService(IMappingService mapper) : ITrendyolOrderService
    {
        private readonly IMappingService _mapper = mapper;
        TrendyolOrderClient _orderClient = new(ApiAuthentication.CreateAuthentication("atBqHAZm2Eg1ZttXGpMZ", "LSEzaIx17XkuFiYyXyRu", "836049"));

        public async Task<IDataResult<GetOrdersResponseDTO>> GetOrdersAsync(OrderQueryParametersModelDTO parameters)
        {
            OrderQueryParametersModel model = _mapper.Map<OrderQueryParametersModel>(parameters);
            var result = await _orderClient.GetOrders(model);
            var responseDto = _mapper.Map<GetOrdersResponseDTO>(result.OkResponse);
            return new DataResult<GetOrdersResponseDTO>(responseDto, result.IsSuccess);
        }

        public async Task<IDataResult> SetFailureOrderPackageAsync(FailureToSupplyReuqestDTO requestDto, string packageId)
        {
            FailureToSupplyReuqest request = _mapper.Map<FailureToSupplyReuqest>(requestDto);
            var result = await _orderClient.SetFailureToSupply(request, packageId);

            return new DataResult(result.IsSuccess);
        }

        public async Task<IDataResult> PickingOrderPackageAsync(UpdatePackageRequestDTO requestDto, string packageId)
        {
            UpdatePackageRequest request = _mapper.Map<UpdatePackageRequest>(requestDto);
            var result = await _orderClient.UpdatePackage(request, packageId);

            return new DataResult(result.IsSuccess);
        }
    }
}
