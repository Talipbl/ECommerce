using ECommerce.Core.Persistence;

namespace ECommerce.Product
{
    public interface IProductImageRepository : IBaseEntityRepository<GnlProductImage>
    {
        ICollection<GnlProductImage> GetImages(int productId);
        GnlProductImage GetImage(string filename);
    }
}
