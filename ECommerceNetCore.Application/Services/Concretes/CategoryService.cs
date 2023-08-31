using ECommerceNetCore.Application.Interfaces;
using ECommerceNetCore.Application.Utilities;
using ECommerceNetCore.Domain;
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

        #region Sub Category
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
        #endregion
    }
}
