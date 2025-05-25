using Ecommerce.Shared.Utilities.Results;
using ECommerce.Application;
using ECommerce.Systems;

namespace ECommerce.Product;

public class ProductOptionService : IProductOptionService
{
    IProductOptionRepository ProductOptionRepo { get; }

    public ProductOptionService(IProductOptionRepository productOptionRepo)
    {
        ProductOptionRepo = productOptionRepo;
    }

    [LogAspect]
    public IDataResult<GnlProductOption> AddProductOption(GnlProductOption option)
    {
        var result = ProductOptionRepo.Add(option);
        return new SuccessDataResult<GnlProductOption>(result);
    }

    public IResult DeleteProductOption(int id)
    {
        throw new NotImplementedException();
    }

    public IListResult<GnlProductOption> GetAllProductOption()
    {
        throw new NotImplementedException();
    }

    public IListResult<GnlProductOption> GetProductOption(int optionId)
    {
        throw new NotImplementedException();
    }

    public IListResult<GnlProductOption> GetProductOptions(int productId, int statusId = 1)
    {
        var result = ProductOptionRepo.GetOptions(productId, statusId);
        return null;
    }

    [LogAspect]
    public IResult UpdateProduct(GnlProduct product)
    {
        var result = ProductOptionRepo.Update(product);
        return new Result(result, EntityConsts.UpdatedSuccess);
    }

    public IResult UpdateProductOption(GnlProductOption option)
    {
        var result = ProductOptionRepo.Update(option);
        return new Result(result);
    }
}
