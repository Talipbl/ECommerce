using ECommerce.Core.Application;
using ECommerce.Systems;

namespace ECommerce.Product;

public interface IProductPriceService
{
    IDataResult<GnlProductPrice> AddProductPrice(GnlProductPrice price);
    IResult UpdateProductPrice(GnlProductPrice price);
    IResult DeleteProductPrice(int id);
    IListResult<GnlProductPrice> GetAllProductPrice();
    IListResult<GnlProductPrice> GetProductPrices(int productId, int optionId = 0, bool onlySale = false, int statusId = (int)StatusTypes.Active);
    IListResult<GnlProductPrice> GetProductPrice(int priceId);
}
