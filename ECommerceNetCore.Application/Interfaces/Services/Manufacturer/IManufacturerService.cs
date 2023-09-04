using ECommerce.Application.Utilities.Results.Abstracts;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Interfaces.Services.Manufacturer
{
    public interface IManufacturerService
    {
        IDataResult<DefAdmin> AddManufacturer(DefManufacturer manufacturer);
        IResult UpdateManufacturer(DefManufacturer manufacturer);
        IResult DeleteManufacturer(int manufacturerId);
        IListResult<DefManufacturer> GetManufacturers();
        IDataResult<DefManufacturer> GetManufacturer(int manufacturerId);
    }
}
