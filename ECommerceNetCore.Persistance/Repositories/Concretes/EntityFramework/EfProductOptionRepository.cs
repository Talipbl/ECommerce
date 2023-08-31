using ECommerceNetCore.Application.Interfaces;
using ECommerceNetCore.Application.Utilities;
using ECommerceNetCore.Domain.Entities;
using ECommerceNetCore.Persistance.Context;

namespace ECommerceNetCore.Persistance.Repositories
{
    public class EfProductOptionRepository : EfBaseEntityRepository<GnlProductOption, EcommerceNetCoreContext>, IProductOptionRepository
    {
        public IListResult<GnlProductOption> GetOptions(int productId, int statusId)
        {
            var result = this.GetAll(x => (x.ProductId == productId) && (statusId != 0 ? x.StatusId == statusId : x.StatusId != statusId)).ToList();
            return new ListResult<GnlProductOption>(result, result.Count);
        }
    }
}
