using ECommerce.Core.Application;

namespace ECommerce.Category;

public class CategoryService : ICategoryService
{
    ICategoryRepository _categoryRepo;
    public CategoryService(ICategoryRepository categoryRepo)
    {
        _categoryRepo = categoryRepo;
    }
    #region Category
    public DefCategory AddCategory(DefCategory category)
    {
        return _categoryRepo.Add(category);
    }

    public IResult DeleteCategory(int categoryId)
    {
        throw new NotImplementedException();
    }

    public IListResult<DefCategory> GetCategories()
    {
        return _categoryRepo.GetCategories();
    }

    public IDataResult<DefCategory> GetCategory(int categoryId)
    {
        return _categoryRepo.GetCategory(categoryId);
    }

    public IResult UpdateCategory(DefCategory category)
    {
        var result = _categoryRepo.Update(category);
        return new Result(result);
    }
    public IListResult<DefCategory> GetCategories(int startRec, int pageSize)
    {
        return _categoryRepo.GetCategories();
    }
    #endregion
}
