using ECommerceNetCore.Application.Interfaces;
using ECommerceNetCore.Domain.Entities;
using ECommerceNetCore.Persistance.Context;

namespace ECommerceNetCore.Persistance.Repositories.EntityFrameworkCore
{
    public class EfProductCategoryRepository : EfBaseEntityRepository<GnlProductCategory, EcommerceNetCoreContext>, IProductCategoryRepository
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
