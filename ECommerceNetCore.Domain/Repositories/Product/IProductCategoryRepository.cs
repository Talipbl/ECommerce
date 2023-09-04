using ECommerce.Domain.Entities;

namespace ECommerce.Application.Interfaces.Repositories.Product
{
    public interface IProductCategoryRepository : IBaseEntityRepository<GnlProductCategory>
    {
        GnlProductCategory GetProductCategory(int productId);
        DefSubCategory GetCategory(int categoryId);
    }
}
