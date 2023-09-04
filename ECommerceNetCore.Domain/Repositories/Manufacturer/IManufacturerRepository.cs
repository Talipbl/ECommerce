using ECommerce.Core.Persistance;

namespace ECommerce.Manufacturer
{
    public interface IManufacturerRepository : IBaseEntityRepository<DefManufacturer>
    {
        IListResult<DefManufacturer> GetManufacturers();
    }
}
