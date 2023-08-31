using ECommerceNetCore.Application.Utilities;
using ECommerceNetCore.Domain.Entities;

namespace ECommerceNetCore.Application.Interfaces
{
    public interface IManufacturerRepository : IBaseEntityRepository<DefManufacturer>
    {
        IListResult<DefManufacturer> GetManufacturers();
    }
}
