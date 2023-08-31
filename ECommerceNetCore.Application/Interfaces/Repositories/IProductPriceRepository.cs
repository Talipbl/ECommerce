using ECommerceNetCore.Application.Utilities;
using ECommerceNetCore.Domain.Entities;

namespace ECommerceNetCore.Application.Interfaces
{
    public interface IProductPriceRepository : IBaseEntityRepository<GnlProductPrice>
    {
        IListResult<GnlProductPrice> GetPrices(int optionId);
        IListResult<GnlProductPrice> GetPricesByProductId(int productId);
    }
}
