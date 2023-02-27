using ECommerceNetCore.Application.Interfaces;
using ECommerceNetCore.Application.Results;
using ECommerceNetCore.Domain.Entities;
using ECommerceNetCore.Persistance.Context;

namespace ECommerceNetCore.Persistance.Repositories
{
    public class EfManufacturerRepository : EfBaseEntityRepository<DefManufacturer, EcommerceNetCoreContext>, IManufacturerRepository
    {
        public IListResult<DefManufacturer> GetManufacturers()
        {
            var result = this.GetAll().ToList();
            return new ListResult<DefManufacturer>(result, result.Count);
        }
    }
}
