using ECommerce.Core.Persistance;

namespace ECommerce.Product
{
    public interface IProductImageRepository : IBaseEntityRepository<GnlProductImage>
    {
        IListResult<GnlProductImage> GetImages(int productId);
        IDataResult<GnlProductImage> GetImage(string filename);
    }
}
