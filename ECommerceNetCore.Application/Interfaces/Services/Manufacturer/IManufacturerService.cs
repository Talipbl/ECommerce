using ECommerce.Core.Application;

namespace ECommerce.Manufacturer;

public interface IManufacturerService
{
    IDataResult<DefManufacturer> AddManufacturer(DefManufacturer manufacturer);
    IResult UpdateManufacturer(DefManufacturer manufacturer);
    IResult DeleteManufacturer(int manufacturerId);
    IListResult<DefManufacturer> GetManufacturers();
    IDataResult<DefManufacturer> GetManufacturer(int manufacturerId);
}
