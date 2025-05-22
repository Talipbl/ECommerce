using ECommerce.Application.Interfaces.Adapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trendyol.Client;

namespace ECommerce.Trendyol
{
    public interface ITrendyolProductAdapter : IAdapter
    {
        ProductModel Adapt(ProductRequestDTO dto);
        ProductRequestDTO Adapt(ProductModel model);
        ProductRequestModel Adapt(List<ProductRequestDTO> items);
        PriceAndInventoryUpdateRequest Adapt(List<PriceAndInventoryUpdateRequestDTO> items);
        FailureToSupplyReuqest Adapt(FailureToSupplyReuqestDTO dto);
    }
}
