using ECommerce.Domain;

namespace ECommerce.Product
{
    public interface IProductPriceRepository : IBaseEntityRepository<GnlProductPrice>
    {
        ICollection<GnlProductPrice> GetPrices(int optionId);
        ICollection<GnlProductPrice> GetPricesByProductId(int productId);
    }
}
