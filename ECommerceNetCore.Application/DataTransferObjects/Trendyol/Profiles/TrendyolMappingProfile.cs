using AutoMapper;
using Marketplace.Trendyol;

namespace ECommerce.Trendyol
{
    public class TrendyolMappingProfile : Profile
    {
        public TrendyolMappingProfile()
        {
            CreateMap<ProductModel, TrendyolProductDto>();
            CreateMap<TrendyolProductDto, ProductModel>();

            CreateMap<ProductModel.RequestAttribute, TrendyolRequestAttributeDto>();
            CreateMap<TrendyolRequestAttributeDto, ProductModel.RequestAttribute>();

            CreateMap<TrendyolImageDto, ImageModel>();
            CreateMap<ImageModel, TrendyolImageDto>();

            CreateMap<DeliveryOptionModel, TrendyolDeliveryOptionDto>();
            CreateMap<TrendyolDeliveryOptionDto, DeliveryOptionModel>();

            CreateMap<TrendyolBatchRequestResultDto, BatchRequestResultModel>();
            CreateMap<BatchRequestResultModel, TrendyolBatchRequestResultDto>();

            CreateMap<TrendyolErrorResultDto, ErrorResultModel>();
            CreateMap<ErrorResultModel, TrendyolErrorResultDto>();

            CreateMap<ErrorModelDto, ErrorResultModel.ErrorModel>();
            CreateMap<ErrorResultModel.ErrorModel, ErrorModelDto>();
        }
    }
}
