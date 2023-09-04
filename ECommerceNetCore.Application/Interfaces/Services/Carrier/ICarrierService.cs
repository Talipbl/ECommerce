using ECommerce.Application.Utilities.Results.Abstracts;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Interfaces.Services.Carrier
{
    public interface ICarrierService
    {
        IDataResult<DefCarrier> AddCarrire(DefCarrier carrier);
        IResult UpdateCarrire(DefCarrier carrier);
        IResult DeleteCarrire(int carrierId);
        IListResult<DefCarrier> GetCarrires(bool isContracted = true);
        IDataResult<DefCarrier> GetCarrire(int carrierId);
    }
}
