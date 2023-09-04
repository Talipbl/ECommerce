using ECommerce.Core.Application;
using ECommerce.Core.Persistance;

namespace ECommerce.Brand
{
    public interface IBrandRepository : IBaseEntityRepository<DefBrand>
    {
        IListResult<DefBrand> GetBrands();
    }
}
