using ECommerce.Domain;

namespace ECommerce.Brand
{
    public interface IBrandRepository : IBaseEntityRepository<DefBrand>
    {
        ICollection<DefBrand> GetBrands();
    }
}
