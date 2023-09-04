using ECommerce.Core.Persistance;

namespace ECommerce.Product
{
    public interface IProductOptionRepository : IBaseEntityRepository<GnlProductOption>
    {
        IListResult<GnlProductOption> GetOptions(int productId, int statusId);
    }
}
