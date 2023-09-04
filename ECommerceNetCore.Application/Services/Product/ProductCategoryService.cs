using ECommerce.Core.Application;

namespace ECommerce.Product;

public class ProductCategoryService : IProductCategoryService
{
    [LogAspect]
    public IDataResult<GnlProductCategory> AddProductCategory(GnlProductCategory category)
    {
        var result = _categoryRepo.Add(category);
        return new SuccessDataResult<GnlProductCategory>(result);
    }

    public IDataResult<GnlProductCategory> GetProductCategory(int productId)
    {
        var category = _categoryRepo.GetProductCategory(productId);
        if (category is null)
        {
            return new DataResult<GnlProductCategory>(false, EntityConsts.DataNotFound);
        }

        return new DataResult<GnlProductCategory>(category, true);
    }

    public IResult UpdateProductCategory(GnlProductCategory productCategory)
    {
        var result = _categoryRepo.Update(productCategory);
        return new Result(result);
    }
}
