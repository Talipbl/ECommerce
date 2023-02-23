using ECommerceNetCore.Application.Interfaces;
using ECommerceNetCore.Application.Results;
using ECommerceNetCore.Domain.Entities;

namespace ECommerceNetCore.Application.Services
{
    public class CategoryService : ICategoryService
    {
        ICategoryRepository _categoryRepo;
        public CategoryService(ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }
        #region Category
        public IDataResult<DefCategory> AddCategory(DefCategory category)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public IResult UpdateCategory(DefCategory category)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Sub Category
        public IDataResult<DefSubCategory> AddSubCategory(DefSubCategory subCategory)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public IResult UpdateSubCategory(DefSubCategory subCategory)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
