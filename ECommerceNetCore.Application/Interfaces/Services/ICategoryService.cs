using ECommerceNetCore.Application.Results;
using ECommerceNetCore.Domain.Common;
using ECommerceNetCore.Domain.Entities;

namespace ECommerceNetCore.Application.Interfaces
{
    public interface ICategoryService
    {
        #region Category
        IDataResult<DefCategory> AddCategory(DefCategory category);
        IResult UpdateCategory(DefCategory category);
        IResult DeleteCategory(int categoryId);
        IListResult<DefCategory> GetCategories();
        IDataResult<DefCategory> GetCategory(int categoryId);
        #endregion

        #region Sub Category
        IDataResult<DefSubCategory> AddSubCategory(DefSubCategory subCategory);
        IResult UpdateSubCategory(DefSubCategory subCategory);
        IResult DeleteSubCategory(int subCategoryId);
        IListResult<DefSubCategory> GetSubCategories(int parentId = (int)CategoryTypes.All);
        IDataResult<DefSubCategory> GetSubCategory(int subCategoryId);
        #endregion
    }
}
