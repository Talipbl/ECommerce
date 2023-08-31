using ECommerceNetCore.Application.Utilities;
using ECommerceNetCore.Domain.Entities;

namespace ECommerceNetCore.Application.Interfaces
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
