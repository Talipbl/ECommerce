using ECommerce.Core.Persistance;
using ECommerce.Category;
using ECommerce.Persistance.Context;

namespace ECommerce.Product
{
    public class EfProductCategoryRepository : EfBaseEntityRepository<GnlProductCategory, ECommerceContext>, IProductCategoryRepository
    {
        public DefSubCategory GetCategory(int categoryId)
        {
            var result = Get<DefSubCategory>(x => x.Id == categoryId);
            return result;
        }

        public GnlProductCategory GetProductCategory(int productId)
        {
            var result = Get(x => x.ProductId == productId);
            return result;
        }
    }
}
