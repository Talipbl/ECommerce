using ECommerceNetCore.Domain.Entities;

namespace ECommerceNetCore.Application.Interfaces
{
    public interface IProductCategoryRepository : IBaseEntityRepository<GnlProductCategory>
    {
        GnlProductCategory GetProductCategory(int productId);
        DefSubCategory GetCategory(int categoryId);
    }
}
