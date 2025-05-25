using ECommerce.EntityFramework;


namespace ECommerce.Product;

public class EfProductPriceRepository : EfBaseEntityRepository<GnlProductPrice, ECommerceContext>, IProductPriceRepository
{
    public ICollection<GnlProductPrice> GetPrices(int optionId)
    {
        var result = GetAll(x => x.OptionId == optionId && x.StatusId == 1).ToList();
        return result;
    }
    public ICollection<GnlProductPrice> GetPricesByProductId(int productId)
    {
        var result = GetAll(x => x.ProductId == productId && x.StatusId == 1).ToList();
        return result;
    }
}
