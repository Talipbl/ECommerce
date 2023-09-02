using ECommerceNetCore.Application.Interfaces;
using ECommerceNetCore.Application.Utilities;
using ECommerceNetCore.Domain.Entities;
using ECommerceNetCore.Persistance.Context;

namespace ECommerceNetCore.Persistance.Repositories.EntityFrameworkCore
{
    public class EfManufacturerRepository : EfBaseEntityRepository<DefManufacturer, EcommerceNetCoreContext>, IManufacturerRepository
    {
        public IListResult<DefManufacturer> GetManufacturers()
        {
            var result = GetAll().ToList();
            return new ListResult<DefManufacturer>(result, result.Count);
        }
    }
}
