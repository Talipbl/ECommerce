using ECommerce.Core.Persistance;
using ECommerce.Category;

namespace ECommerce.Product
{
    public interface IProductCategoryRepository : IBaseEntityRepository<GnlProductCategory>
    {
        GnlProductCategory GetProductCategory(int productId);
        DefSubCategory GetCategory(int categoryId);
    }
}
