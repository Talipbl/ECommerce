using ECommerce.Application.Utilities.Results.Abstracts;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Interfaces.Repositories.Brand
{
    public interface IBrandRepository : IBaseEntityRepository<DefBrand>
    {
        IListResult<DefBrand> GetBrands();
    }
}
