using ECommerce.Core.Application;

namespace ECommerce.Product;

public interface IProductCategoryService
{
    IDataResult<GnlProductCategory> AddProductCategory(GnlProductCategory category);
    IResult UpdateProductCategory(GnlProductCategory productCategory);
    IDataResult<GnlProductCategory> GetProductCategory(int productId);
}
