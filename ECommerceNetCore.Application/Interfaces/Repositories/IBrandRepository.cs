using ECommerceNetCore.Application.Results;
using ECommerceNetCore.Domain.Entities;

namespace ECommerceNetCore.Application.Interfaces
{
    public interface IBrandRepository : IBaseEntityRepository<DefBrand>
    {
        IListResult<DefBrand> GetBrands();
    }
}
