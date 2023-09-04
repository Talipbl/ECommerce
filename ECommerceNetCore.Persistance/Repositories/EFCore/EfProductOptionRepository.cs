using ECommerce.Core.Persistance;
using ECommerce.Application.Interfaces.Repositories;
using ECommerce.Application.Utilities;
using ECommerce.Application.Utilities.Results.Abstracts;
using ECommerce.Domain.Entities;
using ECommerce.Persistance.Context;

namespace ECommerce.Product
{
    public class EfProductOptionRepository : EfBaseEntityRepository<GnlProductOption, ECommerceContext>, IProductOptionRepository
    {
        public IListResult<GnlProductOption> GetOptions(int productId, int statusId)
        {
            var result = GetAll(x => x.ProductId == productId && (statusId != 0 ? x.StatusId == statusId : x.StatusId != statusId)).ToList();
            return new ListResult<GnlProductOption>(result, result.Count);
        }
    }
}
