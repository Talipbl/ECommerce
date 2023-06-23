using ECommerceNetCore.Application.Interfaces;
using ECommerceNetCore.Application.Results;
using ECommerceNetCore.Domain;
using ECommerceNetCore.Domain.Entities;
using ECommerceNetCore.Persistance.Context;
using Microsoft.Data.SqlClient;

namespace ECommerceNetCore.Persistance.Repositories
{
    public class EfCategoryRepository : EfBaseEntityRepository<DefCategory, EcommerceNetCoreContext>, ICategoryRepository
    {
        public DefSubCategory AddSubCategory(DefSubCategory category)
        {
            return this.Add<DefSubCategory>(category);
        }

        public IListResult<DefCategory> GetCategories(int id = 0)
        {
            var result = this.GetAll<DefCategory>(x => id != 0 ? x.Id == id : x.Id != id);
            return new ListResult<DefCategory>(result.ToList(), result.Count());
        }

        public IListResult<DefCategory> GetCategories(int startRec, int pageSize)
        {
            var result = this.GetAll<int>(null, x => x.Id, (int)SortOrder.Descending, startRec, pageSize).ToList();
            var count = this.GetCount();

            return new ListResult<DefCategory>(result, count);
        }

        public IDataResult<DefCategory> GetCategory(int categoryId)
        {
            var result = this.Get(x => x.Id == categoryId);
            return new DataResult<DefCategory>(result, true);
        }

        public IListResult<DefSubCategory> GetSubCategories(int parentId, bool isParent = false)
        {
            var result = this.GetAll<DefSubCategory>(x => (x.ParentId == parentId) && (x.IsParent == isParent));
            return new ListResult<DefSubCategory>(result.ToList(),result.Count());
        }

        public IListResult<CategoryListModel> GetSubCategories(int startRec, int pageSize)
        {
            var result = this.GetAll<int, DefSubCategory>(null, x => x.ParentId, (int)SortOrder.Ascending, startRec, pageSize).Select(x=> new CategoryListModel()
            {
                Id = x.Id,
                CategoryName= x.CategoryName,
                Description= x.Description,
                IsParent= x.IsParent,
                ParentCategory = this.GetSubCategory(x.ParentId).CategoryName,
            }).ToList();
            var count = this.GetCount<DefSubCategory>();

            return new ListResult<CategoryListModel>(result, count);
        }

        public DefSubCategory GetSubCategory(int categoryId)
        {
            var result = this.Get<DefSubCategory>(x => x.Id == categoryId);
            return result;
        }

        public bool UpdateSubCategory(DefSubCategory category)
        {
            return this.Update<DefSubCategory>(category);
        }
    }
}
