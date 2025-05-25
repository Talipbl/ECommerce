using Ecommerce.Shared.Utilities.Results;

namespace ECommerce.Category;

public interface ICategoryService
{
    DefCategory AddCategory(DefCategory category);
    IResult UpdateCategory(DefCategory category);
    IResult DeleteCategory(int categoryId);
    IListResult<DefCategory> GetCategories();
    IListResult<DefCategory> GetCategories(int startRec, int pageSize);
    IDataResult<DefCategory> GetCategory(int categoryId);
}
