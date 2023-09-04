using ECommerce.Application.Utilities.Results.Abstracts;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Interfaces.Repositories.Manufacturer
{
    public interface IManufacturerRepository : IBaseEntityRepository<DefManufacturer>
    {
        IListResult<DefManufacturer> GetManufacturers();
    }
}
