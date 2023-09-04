using ECommerce.Application.Utilities.Results.Abstracts;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Interfaces.Repositories.Product
{
    public interface IProductPriceRepository : IBaseEntityRepository<GnlProductPrice>
    {
        IListResult<GnlProductPrice> GetPrices(int optionId);
        IListResult<GnlProductPrice> GetPricesByProductId(int productId);
    }
}
