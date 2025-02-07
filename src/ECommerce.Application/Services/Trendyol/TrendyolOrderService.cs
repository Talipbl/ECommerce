using AutoMapper;
using ECommerce.Core.Application;
using ECommerce.Trendyol.Order;
using Trendyol.Client;

namespace ECommerce.Trendyol
{
    public class TrendyolOrderService(IMapper mapper) : ITrendyolOrderService
    {
        private readonly IMapper _mapper = mapper;
        TrendyolOrderClient _orderClient = new(ApiAuthentication.CreateAuthentication("atBqHAZm2Eg1ZttXGpMZ", "LSEzaIx17XkuFiYyXyRu", "836049"));

        public async Task<IDataResult<GetOrdersResponseModel>> GetOrdersAsync(OrderQueryParametersModelDto parameters)
        {
            OrderQueryParametersModel model = new()
            {
                StartDate = parameters.StartDate != default ? ((DateTimeOffset)parameters.StartDate).ToUnixTimeSeconds() : null,
                EndDate = parameters.EndDate != default ? ((DateTimeOffset)parameters.EndDate).ToUnixTimeSeconds() : null,
                OrderByDirection = parameters.OrderByDirection,
                OrderByField = parameters.OrderByField,
                OrderNumber = parameters.OrderNumber,
                ShipmentPackageIds = parameters.ShipmentPackageIds,
                Status = parameters.Status,
                SupplierId = parameters.SupplierId,
                Page = parameters.Page,
                Size = parameters.Size
            };

            var result = await _orderClient.GetOrders(model);
            return new DataResult<GetOrdersResponseModel>(result.OkResponse, result.IsSuccess);
        }

        public async Task<IDataResult> SetFailureOrderPackageAsync(FailureToSupplyReuqestDto requestDto, string packageId)
        {
            FailureToSupplyReuqest request = _mapper.Map<FailureToSupplyReuqest>(requestDto);
            var result = await _orderClient.SetFailureToSupply(request, packageId);

            return new DataResult(result.IsSuccess);
        }

        public async Task<IDataResult> UpdateOrderPackageAsync(UpdatePackageRequestDto requestDto, string packageId)
        {
            UpdatePackageRequest request = _mapper.Map<UpdatePackageRequest>(requestDto);
            var result = await _orderClient.UpdatePackage(request, packageId);

            return new DataResult(result.IsSuccess);
        }
    }
}
