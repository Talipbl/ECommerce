using ECommerce.Core.Application;
using ECommerce.Core.Persistence;

namespace ECommerce.Brand
{
    public interface IBrandRepository : IBaseEntityRepository<DefBrand>
    {
        ICollection<DefBrand> GetBrands();
    }
}
