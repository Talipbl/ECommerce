using ECommerce.Core.Persistence;

namespace ECommerce.Manufacturer
{
    public interface IManufacturerRepository : IBaseEntityRepository<DefManufacturer>
    {
        ICollection<DefManufacturer> GetManufacturers();
    }
}
