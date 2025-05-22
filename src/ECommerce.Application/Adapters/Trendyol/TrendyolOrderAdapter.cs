using AutoMapper;
using ECommerce.Application;
using Trendyol.Client;

namespace ECommerce.Trendyol
{
    public class TrendyolOrderAdapter(IMapper mapper) : Adapter (mapper), ITrendyolOrderAdapter
    {
        public FailureToSupplyReuqest AdaptFailureRequest(FailureToSupplyReuqestDTO dto)
        {
            var request = _mapper.Map<FailureToSupplyReuqest>(dto);
            request.ReasonId = (int)dto.Reason;

            return request;
        }

        public UpdatePackageRequest AdaptUpdateRequest(UpdatePackageRequestDTO dto)
        {
            var request = _mapper.Map<UpdatePackageRequest>(dto);
            request.Status = dto.Status.ToString();
            request.Params = new UpdatePackageRequest.ParamsModel { InvoiceNumber = dto.InvoiceNumber };

            return request;
        }
    }
}
