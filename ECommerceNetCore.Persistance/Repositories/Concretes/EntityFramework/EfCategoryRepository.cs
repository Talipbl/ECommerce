using ECommerceNetCore.Application.Interfaces;
using ECommerceNetCore.Application.Results;
using ECommerceNetCore.Domain.Entities;
using ECommerceNetCore.Persistance.Context;

namespace ECommerceNetCore.Persistance.Repositories
{
    public class EfCategoryRepository : EfBaseEntityRepository<DefCategory, EcommerceNetCoreContext>, ICategoryRepository
    {
        public IListResult<DefCategory> GetCategories(int id = 0)
        {
            var result = this.GetAll<DefCategory>(x => id != 0 ? x.Id == id : x.Id != id);
            return new ListResult<DefCategory>(result.ToList(), result.Count());
        }

        public IListResult<DefSubCategory> GetSubCategories(int parentId, bool isParent = false)
        {
            var result = this.GetAll<DefSubCategory>(x => (x.ParentId == parentId) && (x.IsParent == isParent));
            return new ListResult<DefSubCategory>(result.ToList(),result.Count());
        }
    }
}
