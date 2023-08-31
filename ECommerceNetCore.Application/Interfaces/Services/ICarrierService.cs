using ECommerceNetCore.Application.Utilities;
using ECommerceNetCore.Domain.Entities;

namespace ECommerceNetCore.Application.Interfaces
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
