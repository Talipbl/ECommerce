using ECommerce.Application.Adapters;
using Trendyol.Client;

namespace ECommerce.Trendyol
{
    public interface ITrendyolOrderAdapter : IAdapter
    {
        FailureToSupplyReuqest AdaptFailureRequest(FailureToSupplyReuqestDTO dto);
        UpdatePackageRequest AdaptUpdateRequest(UpdatePackageRequestDTO dto);
    }
}
