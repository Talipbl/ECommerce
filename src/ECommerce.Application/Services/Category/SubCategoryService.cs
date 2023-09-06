using ECommerce.Core.Application;

namespace ECommerce.Category;

public class SubCategoryService : ISubCategoryService
{
    ICategoryRepository CategoryRepo { get; }

    public SubCategoryService(ICategoryRepository categoryRepository)
    {
        CategoryRepo = categoryRepository;
    }

    public DefSubCategory AddSubCategory(DefSubCategory subCategory)
    {
        return CategoryRepo.AddSubCategory(subCategory);
    }

    public IResult DeleteSubCategory(int subCategoryId)
    {
        throw new NotImplementedException();
    }

    public IListResult<DefSubCategory> GetSubCategories(int parentId = 0, bool isParent = false)
    {
        //return CategoryRepo.GetSubCategories(parentId, isParent);
        return null;
    }

    public IDataResult<DefSubCategory> GetSubCategory(int subCategoryId)
    {
        return new SuccessDataResult<DefSubCategory>(CategoryRepo.GetSubCategory(subCategoryId));
    }

    public IResult UpdateSubCategory(DefSubCategory subCategory)
    {
        var result = CategoryRepo.UpdateSubCategory(subCategory);
        return new Result(result);
    }
    public IListResult<CategoryListModel> GetSubCategories(int startRec, int pageSize)
    {
        //var result = CategoryRepo.GetSubCategories(startRec, pageSize);

        //AutoMapper ile model eşleştirmeleri yapılacak.
        return new ListResult<CategoryListModel>(new List<CategoryListModel>(), 0);
    }
}
