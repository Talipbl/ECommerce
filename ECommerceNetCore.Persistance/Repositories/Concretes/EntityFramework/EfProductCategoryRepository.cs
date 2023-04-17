using ECommerceNetCore.Application.Interfaces;
using ECommerceNetCore.Domain.Entities;
using ECommerceNetCore.Persistance.Context;

namespace ECommerceNetCore.Persistance.Repositories
{
    public class EfProductCategoryRepository : EfBaseEntityRepository<GnlProductCategory, EcommerceNetCoreContext>, IProductCategoryRepository
    {
        public DefSubCategory GetCategory(int categoryId)
        {
            var result = this.Get<DefSubCategory>(x => x.Id == categoryId);
            return result;
        }

        public GnlProductCategory GetProductCategory(int productId)
        {
            var result = this.Get(x=>x.ProductId == productId);
            return result;
        }
    }
}
