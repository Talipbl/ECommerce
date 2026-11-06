using ECommerce.Core.Persistence;

namespace ECommerce.Product
{
    public interface IProductOptionRepository : IBaseEntityRepository<GnlProductOption>
    {
        ICollection<GnlProductOption> GetOptions(int productId, int statusId);
    }
}
