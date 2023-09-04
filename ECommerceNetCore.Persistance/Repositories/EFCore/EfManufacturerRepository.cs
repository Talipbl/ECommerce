using ECommerce.Application.Interfaces.Repositories;
using ECommerce.Application.Utilities;
using ECommerce.Application.Utilities.Results.Abstracts;
using ECommerce.Domain.Entities;
using ECommerce.Persistance.Context;

namespace ECommerce.Persistance.Repositories.EFCore
{
    public class EfManufacturerRepository : EfBaseEntityRepository<DefManufacturer, ECommerceContext>, IManufacturerRepository
    {
        public IListResult<DefManufacturer> GetManufacturers()
        {
            var result = GetAll().ToList();
            return new ListResult<DefManufacturer>(result, result.Count);
        }
    }
}
