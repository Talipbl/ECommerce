using ECommerce.Application;
using MapsterMapper;
using Trendyol.Client;

namespace ECommerce.Trendyol
{
    public class TrendyolProductAdapter(IMapper mapper) : Adapter(mapper), ITrendyolProductAdapter
    {
        public ProductModel AdaptProductRequest(ProductRequestDTO dto)
        {
            var model = _mapper.Map<ProductModel>(dto);
            model.Images = ToImageModels(dto.Images);
            return model;
        }

        public ProductRequestDTO AdaptProductResponse(ProductModel model)
        {
            var dto = _mapper.Map<ProductRequestDTO>(model);
            dto.Images = model.Images?
                .Where(x => !string.IsNullOrWhiteSpace(x.Url))
                .Select(x => x.Url)
                .ToList();
            return dto;
        }

        public ProductRequestModel AdaptProductsRequest(List<ProductRequestDTO> items)
        {
            return new ProductRequestModel { Items = items.Select(AdaptProductRequest).ToList() };
        }

        public PriceAndInventoryUpdateRequest AdaptPriceAndInventoryRequest(List<PriceAndInventoryUpdateRequestDTO> items)
        {
            return _mapper.Map<PriceAndInventoryUpdateRequest>(items);
        }

        private static List<ImageModel> ToImageModels(List<string>? images) =>
            images?
                .Where(img => !string.IsNullOrWhiteSpace(img))
                .Select(img => new ImageModel { Url = img })
                .ToList() ?? [];
    }
}
