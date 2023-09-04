using ECommerce.Core.Application;

namespace ECommerce.Category;

public class SubCategoryService : ISubCategoryService
{
    public DefSubCategory AddSubCategory(DefSubCategory subCategory)
    {
        return _categoryRepo.AddSubCategory(subCategory);
    }

    public IResult DeleteSubCategory(int subCategoryId)
    {
        throw new NotImplementedException();
    }

    public IListResult<DefSubCategory> GetSubCategories(int parentId = 0, bool isParent = false)
    {
        return _categoryRepo.GetSubCategories(parentId, isParent);
    }

    public IDataResult<DefSubCategory> GetSubCategory(int subCategoryId)
    {
        return new SuccessDataResult<DefSubCategory>(_categoryRepo.GetSubCategory(subCategoryId));
    }

    public IResult UpdateSubCategory(DefSubCategory subCategory)
    {
        var result = _categoryRepo.UpdateSubCategory(subCategory);
        return new Result(result);
    }
    public IListResult<CategoryListModel> GetSubCategories(int startRec, int pageSize)
    {
        return _categoryRepo.GetSubCategories(startRec, pageSize);
    }
}
