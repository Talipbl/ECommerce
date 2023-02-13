using ECommerceNetCore.Application.Interfaces.Services;
using ECommerceNetCore.Application.Results;
using ECommerceNetCore.Domain.Entities;

namespace ECommerceNetCore.Application.Services.Concretes
{
    public class ManufacturerService : IManufacturerService
    {
        public IDataResult<DefAdmin> AddManufacturer(DefManufacturer manufacturer)
        {
            throw new NotImplementedException();
        }

        public IResult DeleteManufacturer(int manufacturerId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<DefManufacturer> GetManufacturer(int manufacturerId)
        {
            throw new NotImplementedException();
        }

        public IListResult<DefManufacturer> GetManufacturers()
        {
            throw new NotImplementedException();
        }

        public IResult UpdateManufacturer(DefManufacturer manufacturer)
        {
            throw new NotImplementedException();
        }
    }
}
