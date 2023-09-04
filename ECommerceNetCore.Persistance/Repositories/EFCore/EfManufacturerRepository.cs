using ECommerce.Core.Persistance;
using ECommerce.Persistance.Context;

namespace ECommerce.Manufacturer
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
