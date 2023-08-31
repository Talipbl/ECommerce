using ECommerceNetCore.Application.Utilities;
using ECommerceNetCore.Domain;
using ECommerceNetCore.Domain.Common;
using ECommerceNetCore.Domain.Entities;

namespace ECommerceNetCore.Application.Interfaces
{
    public interface ICategoryService
    {
        #region Category
        DefCategory AddCategory(DefCategory category);
        IResult UpdateCategory(DefCategory category);
        IResult DeleteCategory(int categoryId);
        IListResult<DefCategory> GetCategories();
        IListResult<DefCategory> GetCategories(int startRec, int pageSize);
        IDataResult<DefCategory> GetCategory(int categoryId);
        #endregion

        #region Sub Category
        DefSubCategory AddSubCategory(DefSubCategory subCategory);
        IResult UpdateSubCategory(DefSubCategory subCategory);
        IResult DeleteSubCategory(int subCategoryId);
        IListResult<DefSubCategory> GetSubCategories(int parentId = (int)CategoryTypes.All, bool isParent = false);
        IDataResult<DefSubCategory> GetSubCategory(int subCategoryId);
        IListResult<CategoryListModel> GetSubCategories(int startRec, int pageSize);
        #endregion
    }
}
