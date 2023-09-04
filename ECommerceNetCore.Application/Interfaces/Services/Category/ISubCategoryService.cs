using ECommerce.Application.DataTransferObjects.Category;
using ECommerce.Core.Application;
using ECommerce.Domain.Common.Enumarations;

namespace ECommerce.Category;

public interface ISubCategoryService
{
    DefSubCategory AddSubCategory(DefSubCategory subCategory);
    IResult UpdateSubCategory(DefSubCategory subCategory);
    IResult DeleteSubCategory(int subCategoryId);
    IListResult<DefSubCategory> GetSubCategories(int parentId = (int)CategoryTypes.All, bool isParent = false);
    IDataResult<DefSubCategory> GetSubCategory(int subCategoryId);
    IListResult<CategoryListModel> GetSubCategories(int startRec, int pageSize);
}
