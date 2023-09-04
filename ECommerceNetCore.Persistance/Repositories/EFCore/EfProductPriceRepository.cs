using ECommerce.Application.Interfaces.Repositories;
using ECommerce.Application.Utilities;
using ECommerce.Application.Utilities.Results.Abstracts;
using ECommerce.Domain.Common.Enumarations;
using ECommerce.Domain.Entities;
using ECommerce.Persistance.Context;

namespace ECommerce.Persistance.Repositories.EFCore
{
    public class EfProductPriceRepository : EfBaseEntityRepository<GnlProductPrice, ECommerceContext>, IProductPriceRepository
    {
        public IListResult<GnlProductPrice> GetPrices(int optionId)
        {
            var result = GetAll(x => x.OptionId == optionId && x.StatusId == (int)StatusTypes.Active).ToList();
            return new ListResult<GnlProductPrice>(result, result.Count);
        }
        public IListResult<GnlProductPrice> GetPricesByProductId(int productId)
        {
            var result = GetAll(x => x.ProductId == productId && x.StatusId == (int)StatusTypes.Active).ToList();
            return new ListResult<GnlProductPrice>(result, result.Count);
        }
    }
}
