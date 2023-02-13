using ECommerceNetCore.Application.Results;
using ECommerceNetCore.Domain.Entities;

namespace ECommerceNetCore.Application.Interfaces.Services
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
