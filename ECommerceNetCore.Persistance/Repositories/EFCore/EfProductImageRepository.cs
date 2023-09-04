using ECommerce.Application.Interfaces.Repositories;
using ECommerce.Application.Utilities;
using ECommerce.Application.Utilities.Results.Abstracts;
using ECommerce.Domain.Entities;
using ECommerce.Persistance.Context;

namespace ECommerce.Persistance.Repositories.EFCore
{
    public class EfProductImageRepository : EfBaseEntityRepository<GnlProductImage, ECommerceContext>, IProductImageRepository
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
