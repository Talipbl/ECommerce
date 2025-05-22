using AutoMapper;
using ECommerce.Trendyol.Order;
using Trendyol.Client;

namespace ECommerce.Trendyol
{
    public class TrendyolOrderMappingProfile: Profile
    {
        public TrendyolOrderMappingProfile()
        {
            CreateMap<GetOrdersResponseModel, GetOrdersResponseDTO>();
            CreateMap<GetOrdersResponseModel.ContentModel, GetOrdersResponseDTO.ContentDTO>()
                .ForMember(dest => dest.OrderDate, opt => opt.ConvertUsing(new UnixMillisecondsToUtcDateTimeConverter(), src => src.OrderDate));

            CreateMap<GetOrdersResponseModel.ShipmentAddress, GetOrdersResponseDTO.AddressDTO>()
                .ForMember(dest => dest.TaxOffice, opt => opt.Ignore())
                .ForMember(dest => dest.TaxNumber, opt => opt.Ignore());

            CreateMap<GetOrdersResponseModel.InvoiceAddress, GetOrdersResponseDTO.AddressDTO>()
                .ForMember(dest => dest.CityCode, opt => opt.Ignore());

            CreateMap<GetOrdersResponseModel.Line, GetOrdersResponseDTO.LineDTO>()
                .ForMember(dest => dest.FastDeliveryOptions, opt => opt.MapFrom(src => src.FastDeliveryOptions));

            CreateMap<GetOrdersResponseModel.DiscountDetail, GetOrdersResponseDTO.DiscountDetailDTO>();
            CreateMap<GetOrdersResponseModel.PackageHistory, GetOrdersResponseDTO.PackageHistoryDTO>();

            CreateMap<OrderQueryParametersModelDTO, OrderQueryParametersModel>();

            CreateMap<FailureToSupplyReuqestDTO, FailureToSupplyReuqest>()
                .ForMember(dest => dest.ReasonId, opt => opt.Ignore());
            CreateMap<FailureToSupplyReuqestDTO.Line, FailureToSupplyReuqest.Line>();

            CreateMap<UpdatePackageRequestDTO, UpdatePackageRequest>()
                .ForMember(dest => dest.Status, opt => opt.Ignore())
                .ForMember(dest => dest.Params, opt => opt.Ignore());
            CreateMap<UpdatePackageRequestDTO.Line, UpdatePackageRequest.Line>();
        }
    }
}
