using ECommerce.Application;
using MapsterMapper;
using Trendyol.Client;

namespace ECommerce.Trendyol
{
    public class TrendyolOrderAdapter(IMapper mapper) : Adapter(mapper), ITrendyolOrderAdapter
    {
        public FailureToSupplyReuqest AdaptFailureRequest(FailureToSupplyReuqestDTO dto)
        {
            return _mapper.Map<FailureToSupplyReuqest>(dto);
        }

        public UpdatePackageRequest AdaptUpdateRequest(UpdatePackageRequestDTO dto)
        {
            return _mapper.Map<UpdatePackageRequest>(dto);
        }
    }
}
