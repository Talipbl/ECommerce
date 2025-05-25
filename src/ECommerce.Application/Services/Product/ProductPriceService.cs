using Ecommerce.Shared.Utilities.Results;
using ECommerce.Application;

namespace ECommerce.Product;

public class ProductPriceService : IProductPriceService
{
    IProductPriceRepository ProductPriceRepo { get; }

    public ProductPriceService(IProductPriceRepository productPriceRepo)
    {
        ProductPriceRepo = productPriceRepo;
    }

    [LogAspect]
    public IDataResult<GnlProductPrice> AddProductPrice(GnlProductPrice price)
    {
        var result = ProductPriceRepo.Add(price);
        return new SuccessDataResult<GnlProductPrice>(result);
    }

    public IResult DeleteProductPrice(int id)
    {
        throw new NotImplementedException();
    }

    public IListResult<GnlProductPrice> GetAllProductPrice()
    {
        throw new NotImplementedException();
    }

    public IListResult<GnlProductPrice> GetProductPrices(int productId, int optionId = 0, bool onlySale = false, int statusId = 1)
    {
        throw new NotImplementedException();
    }

    public IResult UpdateProductPrice(GnlProductPrice price)
    {
        throw new NotImplementedException();
    }

    public IListResult<GnlProductPrice> GetProductPrice(int priceId)
    {
        throw new NotImplementedException();
    }
}
