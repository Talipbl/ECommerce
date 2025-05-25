using ECommerce.EntityFramework;


namespace ECommerce.Product;

public class EfProductImageRepository : EfBaseEntityRepository<GnlProductImage, ECommerceContext>, IProductImageRepository
{
    public GnlProductImage GetImage(string filename)
    {
        var result = Get(x => x.ImageUrl == filename);
        return result;
    }

    public ICollection<GnlProductImage> GetImages(int productId)
    {
        var result = GetAll(x => x.ProductId == productId).ToList();
        return result;
    }
}
