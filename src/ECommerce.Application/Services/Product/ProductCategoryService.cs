using ECommerce.Category;
using ECommerce.Core.Application;
using ECommerce.Systems;

namespace ECommerce.Product;

public class ProductCategoryService : IProductCategoryService
{
    IProductCategoryRepository ProductCategoryRepo { get; }

    public ProductCategoryService(IProductCategoryRepository categoryRepo)
    {
        ProductCategoryRepo = categoryRepo;
    }

    [LogAspect]
    public IDataResult<GnlProductCategory> AddProductCategory(GnlProductCategory category)
    {
        var result = ProductCategoryRepo.Add(category);
        return new SuccessDataResult<GnlProductCategory>(result);
    }

    public IDataResult<GnlProductCategory> GetProductCategory(int productId)
    {
        var category = ProductCategoryRepo.GetProductCategory(productId);
        if (category is null)
        {
            return new DataResult<GnlProductCategory>(false, EntityConsts.DataNotFound);
        }

        return new DataResult<GnlProductCategory>(category, true);
    }

    public IResult UpdateProductCategory(GnlProductCategory productCategory)
    {
        var result = ProductCategoryRepo.Update(productCategory);
        return new Result(result);
    }
}
