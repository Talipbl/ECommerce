using ECommerce.EntityFramework;

namespace ECommerce.Brand;

public class EfBrandRepository : EfBaseEntityRepository<DefBrand, ECommerceContext>, IBrandRepository
{
    public ICollection<DefBrand> GetBrands()
    {
        var result = GetAll().ToList();
        return result;
    }
}
