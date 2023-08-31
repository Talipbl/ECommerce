using ECommerceNetCore.Application.Interfaces;
using ECommerceNetCore.Application.Utilities;
using ECommerceNetCore.Domain.Entities;

namespace ECommerceNetCore.Application.Services
{
    public class ManufacturerService : IManufacturerService
    {
        IManufacturerRepository _manufacturerRepo;

        public ManufacturerService(IManufacturerRepository manufacturerRepo)
        {
            _manufacturerRepo = manufacturerRepo;
        }

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
            return _manufacturerRepo.GetManufacturers();
        }

        public IResult UpdateManufacturer(DefManufacturer manufacturer)
        {
            throw new NotImplementedException();
        }
    }
}
