using ECommerceNetCore.Application.Interfaces;
using ECommerceNetCore.Application.Results;
using ECommerceNetCore.Domain.Entities;
using ECommerceNetCore.Persistance.Context;

namespace ECommerceNetCore.Persistance.Repositories
{
    public class EfProductRepository : EfBaseEntityRepository<GnlProduct, EcommerceNetCoreContext>, IProductRepository
    {
        public IDataResult<GnlProduct> GetProduct(string productName)
        {
            var result = this.Get(x => x.Name == productName);
            return new SuccessDataResult<GnlProduct>(result);
        }
    }
}
