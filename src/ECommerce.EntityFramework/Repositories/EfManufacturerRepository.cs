using ECommerce.EntityFramework;


namespace ECommerce.Manufacturer;

public class EfManufacturerRepository : EfBaseEntityRepository<DefManufacturer, ECommerceContext>, IManufacturerRepository
{
    public ICollection<DefManufacturer> GetManufacturers()
    {
        var result = GetAll().ToList();
        return result;
    }
}
