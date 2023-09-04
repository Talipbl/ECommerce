using ECommerce.Core.Persistance;
using ECommerce.Persistance.Context;

namespace ECommerce.Product
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
