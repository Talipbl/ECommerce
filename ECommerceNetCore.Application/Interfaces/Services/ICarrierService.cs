using ECommerceNetCore.Application.Results;
using ECommerceNetCore.Domain.Entities;

namespace ECommerceNetCore.Application.Interfaces.Services
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
