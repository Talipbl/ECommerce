using ECommerce.Core.Application;

namespace ECommerce.Product;

public class ProductOptionService : IProductOptionService
{
    [LogAspect]
    public IDataResult<GnlProductOption> AddProductOption(GnlProductOption option)
    {
        var result = _optionRepo.Add(option);
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
        return _optionRepo.GetOptions(productId, statusId);
    }

    [LogAspect]
    public IResult UpdateProduct(GnlProduct product)
    {
        var result = _productRepo.Update(product);
        return new Result(result, EntityConsts.UpdatedSuccess);
    }

    public IResult UpdateProductOption(GnlProductOption option)
    {
        var result = _optionRepo.Update(option);
        return new Result(result);
    }
}
