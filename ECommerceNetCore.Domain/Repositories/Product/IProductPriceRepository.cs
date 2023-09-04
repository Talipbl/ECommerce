using ECommerce.Core.Persistance;

namespace ECommerce.Product
{
    public interface IProductPriceRepository : IBaseEntityRepository<GnlProductPrice>
    {
        IListResult<GnlProductPrice> GetPrices(int optionId);
        IListResult<GnlProductPrice> GetPricesByProductId(int productId);
    }
}
