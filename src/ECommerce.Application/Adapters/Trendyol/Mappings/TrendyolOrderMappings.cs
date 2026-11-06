using ECommerce.Trendyol.Order;
using Mapster;
using Trendyol.Client;

namespace ECommerce.Trendyol;

public class TrendyolOrderMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<GetOrdersResponseModel.ContentModel, GetOrdersResponseDTO.ContentDTO>()
            .Map(dest => dest.OrderDate, src => DateTimeOffset.FromUnixTimeMilliseconds(src.OrderDate).UtcDateTime);
        config.NewConfig<GetOrdersResponseModel.ShipmentAddress, GetOrdersResponseDTO.AddressDTO>();
        config.NewConfig<GetOrdersResponseModel.InvoiceAddress, GetOrdersResponseDTO.AddressDTO>();

        config.NewConfig<FailureToSupplyReuqestDTO, FailureToSupplyReuqest>()
            .Map(dest => dest.ReasonId, src => (int)src.Reason);
        config.NewConfig<UpdatePackageRequestDTO, UpdatePackageRequest>()
            .Map(dest => dest.Status, src => src.Status.ToString())
            .Map(dest => dest.Params, src => new UpdatePackageRequest.ParamsModel { InvoiceNumber = src.InvoiceNumber });
    }
}
