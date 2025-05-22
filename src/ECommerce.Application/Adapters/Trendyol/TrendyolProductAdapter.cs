using AutoMapper;
using ECommerce.Application;
using Trendyol.Client;

namespace ECommerce.Trendyol
{
    public class TrendyolProductAdapter(IMapper mapper) : Adapter(mapper), ITrendyolProductAdapter
    {
        public ProductModel Adapt(ProductRequestDTO dto)
        {
            return _mapper.Map<ProductModel>(dto);
        }

        public ProductRequestDTO Adapt(ProductModel model)
        {
            var dto = _mapper.Map<ProductRequestDTO>(model);

            dto.Images = model.Images?
            .Where(x => !string.IsNullOrWhiteSpace(x.Url))
            .Select(x => x.Url)
            .ToList();

            return dto;
        }

        public ProductRequestModel Adapt(List<ProductRequestDTO> items)
        {
            return _mapper.Map<ProductRequestModel>(items);
        }

        public PriceAndInventoryUpdateRequest Adapt(List<PriceAndInventoryUpdateRequestDTO> items)
        {
            return _mapper.Map<PriceAndInventoryUpdateRequest>(items);
        }

        public FailureToSupplyReuqest Adapt(FailureToSupplyReuqestDTO dto)
        {
            return _mapper.Map<FailureToSupplyReuqest>(dto);
        }
    }
}
