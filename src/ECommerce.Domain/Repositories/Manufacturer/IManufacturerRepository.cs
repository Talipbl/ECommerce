using ECommerce.Core.Persistance;

namespace ECommerce.Manufacturer
{
    public interface IManufacturerRepository : IBaseEntityRepository<DefManufacturer>
    {
        ICollection<DefManufacturer> GetManufacturers();
    }
}
