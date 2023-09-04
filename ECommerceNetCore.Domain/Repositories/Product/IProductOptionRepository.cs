using ECommerce.Application.Utilities.Results.Abstracts;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Interfaces.Repositories.Product
{
    public interface IProductOptionRepository : IBaseEntityRepository<GnlProductOption>
    {
        IListResult<GnlProductOption> GetOptions(int productId, int statusId);
    }
}
