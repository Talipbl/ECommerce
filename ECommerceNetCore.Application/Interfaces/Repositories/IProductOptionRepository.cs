using ECommerceNetCore.Application.Utilities;
using ECommerceNetCore.Domain.Entities;

namespace ECommerceNetCore.Application.Interfaces
{
    public interface IProductOptionRepository : IBaseEntityRepository<GnlProductOption>
    {
        IListResult<GnlProductOption> GetOptions(int productId, int statusId);
    }
}
