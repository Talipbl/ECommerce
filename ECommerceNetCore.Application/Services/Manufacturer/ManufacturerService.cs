using ECommerce.Application.Interfaces.Repositories.Manufacturer;
using ECommerce.Application.Interfaces.Services.Manufacturer;
using ECommerce.Application.Utilities.Results.Abstracts;
using ECommerce.Domain.Entities;

namespace ECommerce.Manufacturer
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
