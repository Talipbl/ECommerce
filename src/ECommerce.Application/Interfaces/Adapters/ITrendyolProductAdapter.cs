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
        ProductModel AdaptProductRequest(ProductRequestDTO dto);
        ProductRequestDTO AdaptProductResponse(ProductModel model);
        ProductRequestModel AdaptProductsRequest(List<ProductRequestDTO> items);
        PriceAndInventoryUpdateRequest AdaptPriceAndInventoryRequest(List<PriceAndInventoryUpdateRequestDTO> items);
    }
}
