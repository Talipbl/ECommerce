using AutoMapper;
using Trendyol.Client;
using static Trendyol.Client.GetProductsResponseModel;

namespace ECommerce.Trendyol
{
    public class TrendyolProductMappingProfile : Profile
    {
        public TrendyolProductMappingProfile()
        {
            CreateMap<ProductModel, ProductRequestDTO>()
                .ForMember(dest => dest.Images, opt => opt.Ignore());
            CreateMap<ProductRequestDTO, ProductModel>()
                .ForMember(dest => dest.Images, opt => opt.Ignore());
            CreateMap<List<ProductRequestDTO>, ProductRequestModel>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src));

            CreateMap<ProductModel.RequestAttribute, RequestAttributeDTO>();
            CreateMap<RequestAttributeDTO, ProductModel.RequestAttribute>();

            CreateMap<DeliveryOptionModel, DeliveryOptionDTO>();
            CreateMap<DeliveryOptionDTO, DeliveryOptionModel>();

            CreateMap<string, DeleteProductRequestModel.DeleteProduct>()
                .ForMember(dest => dest.Barcode, opt => opt.MapFrom(src => src));
            CreateMap<List<string>, DeleteProductRequestModel>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src));

            CreateMap<BatchRequestResultModel, TrendyolBatchRequestResultDTO>();
            CreateMap<BatchRequestResultModel.Item, TrendyolBatchRequestResultDTO.Item>().
                ForMember(dest => dest.RequestItem, opt => opt.MapFrom(src => src.RequestItem.Product.Items));

            CreateMap<PriceAndInventoryUpdateRequestDTO, PriceAndInventoryModel>();
            CreateMap<List<PriceAndInventoryUpdateRequestDTO>, PriceAndInventoryUpdateRequest>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src));

            CreateMap<ProductQueryParametersDTO, ProductQueryParametersModel>();

            CreateMap<BrandModel, BrandResponseDTO>();
            CreateMap<CategoryModel, CategoryResponseDTO>();

            CreateMap<GetProductsResponseModel, ProductsResponseDTO>();
            CreateMap<GetProductsResponseModel.ContentModel, ProductsResponseDTO.ContentDTO>()
                .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images.Select(x => x.Url)));
            CreateMap<ResponseAttribute, ResponseAttributeDTO>();

        }
    }
}
