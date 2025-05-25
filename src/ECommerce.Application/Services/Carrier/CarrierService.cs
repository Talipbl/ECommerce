using Ecommerce.Shared.Utilities.Results;

namespace ECommerce.Carrier;

public class CarrierService : ICarrierService
{
    public IDataResult<DefCarrier> AddCarrire(DefCarrier carrier)
    {
        throw new NotImplementedException();
    }

    public IResult DeleteCarrire(int carrierId)
    {
        throw new NotImplementedException();
    }

    public IDataResult<DefCarrier> GetCarrire(int carrierId)
    {
        throw new NotImplementedException();
    }

    public IListResult<DefCarrier> GetCarrires(bool isContracted = true)
    {
        throw new NotImplementedException();
    }

    public IResult UpdateCarrire(DefCarrier carrier)
    {
        throw new NotImplementedException();
    }
}
