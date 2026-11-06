using Mapster;
using Trendyol.Client;

namespace ECommerce.Trendyol;

public class TrendyolProductMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<ProductModel, ProductRequestDTO>().Ignore(dest => dest.Images);
        config.NewConfig<ProductRequestDTO, ProductModel>().Ignore(dest => dest.Images);

        config.NewConfig<string, DeleteProductRequestModel.DeleteProduct>()
            .MapWith(src => new DeleteProductRequestModel.DeleteProduct { Barcode = src });
        config.NewConfig<List<string>, DeleteProductRequestModel>().Map(dest => dest.Items, src => src);

        config.NewConfig<List<PriceAndInventoryUpdateRequestDTO>, PriceAndInventoryUpdateRequest>()
            .Map(dest => dest.Items, src => src);

        config.NewConfig<BatchRequestResultModel.Item, TrendyolBatchRequestResultDTO.Item>()
            .Map(dest => dest.RequestItem, src => src.RequestItem.Product.Items);

        config.NewConfig<GetProductsResponseModel.ContentModel, ProductsResponseDTO.ContentDTO>()
            .Map(dest => dest.Images, src => src.Images == null ? null : src.Images.Select(x => x.Url).ToList());
    }
}
