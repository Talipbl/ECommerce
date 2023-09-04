using ECommerce.Core.Persistance;

namespace ECommerce.Product
{
    public interface IProductOptionRepository : IBaseEntityRepository<GnlProductOption>
    {
        ICollection<GnlProductOption> GetOptions(int productId, int statusId);
    }
}
