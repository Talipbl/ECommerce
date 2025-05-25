using AutoMapper;
using ECommerce.Application;
using Trendyol.Client;

namespace ECommerce.Trendyol
{
    public class TrendyolProductAdapter(IMapper mapper) : Adapter(mapper), ITrendyolProductAdapter
    {
        public ProductModel AdaptProductRequest(ProductRequestDTO dto)
        {
            return _mapper.Map<ProductModel>(dto);
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
            var request = _mapper.Map<ProductRequestModel>(items);
            for (int i = 0; i < request.Items.Count && i < items.Count; i++)
            {
                var dtoImages = items[i].Images;
                request.Items[i].Images = dtoImages != null
                    ? dtoImages
                        .Where(img => !string.IsNullOrWhiteSpace(img))
                        .Select(img => new ImageModel { Url = img })
                        .ToList()
                    : new List<ImageModel>();
            }
            return request;
        }

        public PriceAndInventoryUpdateRequest AdaptPriceAndInventoryRequest(List<PriceAndInventoryUpdateRequestDTO> items)
        {
            return _mapper.Map<PriceAndInventoryUpdateRequest>(items);
        }
    }
}
