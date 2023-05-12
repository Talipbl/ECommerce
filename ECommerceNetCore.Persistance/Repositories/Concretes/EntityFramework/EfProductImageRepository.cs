using ECommerceNetCore.Application.Interfaces;
using ECommerceNetCore.Application.Results;
using ECommerceNetCore.Domain.Entities;
using ECommerceNetCore.Persistance.Context;

namespace ECommerceNetCore.Persistance.Repositories
{
    public class EfProductImageRepository : EfBaseEntityRepository<GnlProductImage, EcommerceNetCoreContext>, IProductImageRepository
    {
        public IDataResult<GnlProductImage> GetImage(string filename)
        {
            var result = this.Get(x => x.ImageUrl == filename);
            return new SuccessDataResult<GnlProductImage>(result);
        }

        public IListResult<GnlProductImage> GetImages(int productId)
        {
            var result = this.GetAll(x => x.ProductId == productId).ToList();
            return new ListResult<GnlProductImage>(result, result.Count);
        }
    }
}
