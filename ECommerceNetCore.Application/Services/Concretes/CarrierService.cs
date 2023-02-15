using ECommerceNetCore.Application.Interfaces;
using ECommerceNetCore.Application.Results;
using ECommerceNetCore.Domain.Entities;

namespace ECommerceNetCore.Application.Services
{
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
}
