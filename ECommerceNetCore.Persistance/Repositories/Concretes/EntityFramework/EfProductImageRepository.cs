using ECommerceNetCore.Application.Interfaces;
using ECommerceNetCore.Application.Results;
using ECommerceNetCore.Domain.Entities;
using ECommerceNetCore.Persistance.Context;

namespace ECommerceNetCore.Persistance.Repositories
{
    public class EfProductImageRepository : EfBaseEntityRepository<GnlProductImage, EcommerceNetCoreContext>, IProductImageRepository
    {
        public IListResult<GnlProductImage> GetIamges(int optionId)
        {
            var result = this.GetAll(x => x.OptionId == optionId).ToList();
            return new ListResult<GnlProductImage>(result, result.Count);
        }
    }
}
