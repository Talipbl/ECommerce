using ECommerceNetCore.Application.Interfaces;
using ECommerceNetCore.Domain.Entities;
using ECommerceNetCore.Persistance.Context;

namespace ECommerceNetCore.Persistance.Repositories
{
    public class EfProductCategoryRepository : EfBaseEntityRepository<GnlProductCategory, EcommerceNetCoreContext>, IProductCategoryRepository
    {
        public GnlProductCategory GetProductCategory(int productId)
        {
            var result = this.Get(x=>x.ProductId== productId);
            return result;
        }
    }
}
