using ECommerceNetCore.Application.Results;
using ECommerceNetCore.Domain.Entities;

namespace ECommerceNetCore.Application.Interfaces
{
    public interface IManufacturerRepository : IBaseEntityRepository<DefManufacturer>
    {
        IListResult<DefManufacturer> GetManufacturers();
    }
}
