using ECommerce.Domain;

namespace ECommerce.Manufacturer
{
    public interface IManufacturerRepository : IBaseEntityRepository<DefManufacturer>
    {
        ICollection<DefManufacturer> GetManufacturers();
    }
}
