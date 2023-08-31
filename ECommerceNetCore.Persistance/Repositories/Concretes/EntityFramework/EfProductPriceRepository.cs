using ECommerceNetCore.Application.Interfaces;
using ECommerceNetCore.Application.Utilities;
using ECommerceNetCore.Domain.Common;
using ECommerceNetCore.Domain.Entities;
using ECommerceNetCore.Persistance.Context;

namespace ECommerceNetCore.Persistance.Repositories
{
    public class EfProductPriceRepository : EfBaseEntityRepository<GnlProductPrice, EcommerceNetCoreContext>, IProductPriceRepository
    {
        public IListResult<GnlProductPrice> GetPrices(int optionId)
        {
            var result = this.GetAll(x => x.OptionId == optionId && x.StatusId == (int)StatusTypes.Active).ToList();
            return new ListResult<GnlProductPrice>(result, result.Count);
        }
        public IListResult<GnlProductPrice> GetPricesByProductId(int productId)
        {
            var result = this.GetAll(x => x.ProductId == productId && x.StatusId == (int)StatusTypes.Active).ToList();
            return new ListResult<GnlProductPrice>(result, result.Count);
        }
    }
}
