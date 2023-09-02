using ECommerceNetCore.Application.Interfaces;
using ECommerceNetCore.Application.Utilities;
using ECommerceNetCore.Domain;
using ECommerceNetCore.Domain.Entities;
using ECommerceNetCore.Persistance.Context;
using Microsoft.Data.SqlClient;

namespace ECommerceNetCore.Persistance.Repositories.EntityFrameworkCore
{
    public class EfCategoryRepository : EfBaseEntityRepository<DefCategory, EcommerceNetCoreContext>, ICategoryRepository
    {
        public DefSubCategory AddSubCategory(DefSubCategory category)
        {
            return Add(category);
        }

        public IListResult<DefCategory> GetCategories(int id = 0)
        {
            var result = GetAll<DefCategory>(x => id != 0 ? x.Id == id : x.Id != id);
            return new ListResult<DefCategory>(result.ToList(), result.Count());
        }

        public IListResult<DefCategory> GetCategories(int startRec, int pageSize)
        {
            var result = GetAll(null, x => x.Id, (int)SortOrder.Descending, startRec, pageSize).ToList();
            var count = GetCount();

            return new ListResult<DefCategory>(result, count);
        }

        public IDataResult<DefCategory> GetCategory(int categoryId)
        {
            var result = Get(x => x.Id == categoryId);
            return new DataResult<DefCategory>(result, true);
        }

        public IListResult<DefSubCategory> GetSubCategories(int parentId, bool isParent = false)
        {
            var result = GetAll<DefSubCategory>(x => x.ParentId == parentId && x.IsParent == isParent);
            return new ListResult<DefSubCategory>(result.ToList(), result.Count());
        }

        public IListResult<CategoryListModel> GetSubCategories(int startRec, int pageSize)
        {
            var result = GetAll<int, DefSubCategory>(null, x => x.ParentId, (int)SortOrder.Ascending, startRec, pageSize).Select(x => new CategoryListModel()
            {
                Id = x.Id,
                CategoryName = x.CategoryName,
                Description = x.Description,
                IsParent = x.IsParent,
                ParentCategory = GetSubCategory(x.ParentId).CategoryName,
            }).ToList();
            var count = GetCount<DefSubCategory>();

            return new ListResult<CategoryListModel>(result, count);
        }

        public DefSubCategory GetSubCategory(int categoryId)
        {
            var result = Get<DefSubCategory>(x => x.Id == categoryId);
            return result;
        }

        public bool UpdateSubCategory(DefSubCategory category)
        {
            return Update(category);
        }
    }
}
