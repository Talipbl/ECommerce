
using ECommerce.Carrier;
using ECommerce.Core.Application;

namespace ECommerce.Carrier;

public interface ICarrierService
{
    IDataResult<DefCarrier> AddCarrire(DefCarrier carrier);
    IResult UpdateCarrire(DefCarrier carrier);
    IResult DeleteCarrire(int carrierId);
    IListResult<DefCarrier> GetCarrires(bool isContracted = true);
    IDataResult<DefCarrier> GetCarrire(int carrierId);
}
