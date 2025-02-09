using AutoMapper;
using ECommerce.Trendyol.Order;
using Trendyol.Client;
using static ECommerce.Trendyol.FailureToSupplyReuqestDTO;
using static ECommerce.Trendyol.UpdatePackageRequestDTO;
using static Trendyol.Client.UpdatePackageRequest;

namespace ECommerce.Trendyol
{
    public class TrendyolMappingProfile : Profile
    {
        public TrendyolMappingProfile()
        {
            #region Type Convert

            CreateMap<DateTime, long>().ConvertUsing(new DateTimeConverter());

            //NOTE: orderDate, Timestamp (milliseconds) formatında GMT +3 olarak iletilir. createdDate bilgileri ise GMT formatında iletilir. Convert işlemi yaparken bu bilgiye dikkat edilmelidir.
            CreateMap<long, DateTime>().ConvertUsing(new UnixMillisecondsToDateTimeConverter());
            CreateMap<QueryOption, QueryBooleanOption>().ConvertUsing<QueryOptionConverter>();

            #endregion

            CreateMap<ProductModel, TrendyolProductDTO>()
                .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images.Select(x => x.Url)));
            CreateMap<TrendyolProductDTO, ProductModel>()
                .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images.Select(url => new ImageModel() { Url = url })));

            CreateMap<ProductModel.RequestAttribute, TrendyolRequestAttributeDTO>();
            CreateMap<TrendyolRequestAttributeDTO, ProductModel.RequestAttribute>();

            CreateMap<DeliveryOptionModel, TrendyolProductDTO.TrendyolDeliveryOptionDTO>();
            CreateMap<TrendyolProductDTO.TrendyolDeliveryOptionDTO, DeliveryOptionModel>();

            CreateMap<BatchRequestResultModel, TrendyolBatchRequestResultDTO>();
            CreateMap<BatchRequestResultModel.Item, TrendyolBatchRequestResultDTO.Item>().
                ForMember(dest => dest.RequestItem, opt => opt.MapFrom(src => src.RequestItem.Product.Items));

            CreateMap<ErrorResultModel, TrendyolErrorResultDTO>();
            CreateMap<ErrorResultModel.ErrorModel, TrendyolErrorResultDTO.ErrorModelDTO>();

            CreateMap<TrendyolPriceAndInventoryDTO, PriceAndInventoryModel>();

            CreateMap<ProductQueryParametersDTO, ProductQueryParametersModel>();

            CreateMap<GetOrdersResponseModel, GetOrdersResponseDTO>();
            CreateMap<GetOrdersResponseModel.ContentModel, GetOrdersResponseDTO.ContentDTO>()
                .ForMember(dest => dest.OrderDate, opt => opt.ConvertUsing(new UnixMillisecondsToUtcDateTimeConverter(), src => src.OrderDate));
            CreateMap<GetOrdersResponseModel.ShipmentAddress, GetOrdersResponseDTO.AddressDTO>()
                .ForMember(dest => dest.TaxOffice, opt => opt.Ignore())
                .ForMember(dest => dest.TaxNumber, opt => opt.Ignore());
            CreateMap<GetOrdersResponseModel.InvoiceAddress, GetOrdersResponseDTO.AddressDTO>()
                .ForMember(dest => dest.CityCode, opt => opt.Ignore());
            CreateMap<GetOrdersResponseModel.Line, GetOrdersResponseDTO.LineDTO>()
                .ForMember(dest => dest.FastDeliveryOptions, opt => opt.MapFrom(src => src.FastDeliveryOptions.Select(option => option)));
            CreateMap<GetOrdersResponseModel.DiscountDetail, GetOrdersResponseDTO.DiscountDetailDTO>();
            CreateMap<GetOrdersResponseModel.PackageHistory, GetOrdersResponseDTO.PackageHistoryDTO>();

            CreateMap<OrderQueryParametersModelDTO, OrderQueryParametersModel>();

            CreateMap<FailureToSupplyReuqestDTO, FailureToSupplyReuqest>()
                .ForMember(dest => dest.ReasonId, opt => opt.MapFrom<ReasonResolver>());
            CreateMap<FailureToSupplyReuqestDTO.Line, FailureToSupplyReuqest.Line>();

            CreateMap<UpdatePackageRequestDTO, UpdatePackageRequest>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom<StatusResolver>())
                .ForMember(dest => dest.Params, opt => opt.MapFrom(src => new ParamsModel() { InvoiceNumber = src.InvoiceNumber }));
            CreateMap<UpdatePackageRequestDTO.Line, UpdatePackageRequest.Line>();
        }
    }
}
