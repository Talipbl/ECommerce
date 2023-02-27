using ECommerceNetCore.Application.Interfaces;
using ECommerceNetCore.Application.Results;
using ECommerceNetCore.Domain.Entities;
using ECommerceNetCore.Persistance.Context;

namespace ECommerceNetCore.Persistance.Repositories
{
    public class EfProductOptionRepository : EfBaseEntityRepository<GnlProductOption, EcommerceNetCoreContext>, IProductOptionRepository
    {
        public IListResult<GnlProductOption> GetOptions(int productId)
        {
            var result = this.GetAll(x=>x.ProductId == productId).ToList();
            return new ListResult<GnlProductOption>(result, result.Count);
        }
    }
}
