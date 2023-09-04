using ECommerce.Core.Application;

namespace ECommerce.Manufacturer;

public class ManufacturerService : IManufacturerService
{
    IManufacturerRepository _manufacturerRepo;

    public ManufacturerService(IManufacturerRepository manufacturerRepo)
    {
        _manufacturerRepo = manufacturerRepo;
    }

    public IDataResult<DefManufacturer> AddManufacturer(DefManufacturer manufacturer)
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
