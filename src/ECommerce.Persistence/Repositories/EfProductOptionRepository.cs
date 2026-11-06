using ECommerce.Core.Persistence;
using ECommerce.Persistence;

namespace ECommerce.Product;

public class EfProductOptionRepository : EfBaseEntityRepository<GnlProductOption, ECommerceContext>, IProductOptionRepository
{
    public ICollection<GnlProductOption> GetOptions(int productId, int statusId)
    {
        var result = GetAll(x => x.ProductId == productId && (statusId != 0 ? x.StatusId == statusId : x.StatusId != statusId)).ToList();
        return result;
    }
}
