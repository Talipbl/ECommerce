using ECommerceNetCore.Application.Interfaces;
using ECommerceNetCore.Application.Utilities;
using ECommerceNetCore.Domain.Entities;
using ECommerceNetCore.Persistance.Context;

namespace ECommerceNetCore.Persistance.Repositories.EntityFrameworkCore
{
    public class EfProductImageRepository : EfBaseEntityRepository<GnlProductImage, EcommerceNetCoreContext>, IProductImageRepository
    {
        public IDataResult<GnlProductImage> GetImage(string filename)
        {
            var result = Get(x => x.ImageUrl == filename);
            return new SuccessDataResult<GnlProductImage>(result);
        }

        public IListResult<GnlProductImage> GetImages(int productId)
        {
            var result = GetAll(x => x.ProductId == productId).ToList();
            return new ListResult<GnlProductImage>(result, result.Count);
        }
    }
}
