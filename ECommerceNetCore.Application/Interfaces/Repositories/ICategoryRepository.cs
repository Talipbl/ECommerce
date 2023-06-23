using ECommerceNetCore.Application.Results;
using ECommerceNetCore.Domain;
using ECommerceNetCore.Domain.Common;
using ECommerceNetCore.Domain.Entities;

namespace ECommerceNetCore.Application.Interfaces
{
    public interface ICategoryRepository : IBaseEntityRepository<DefCategory>
    {
        IListResult<DefCategory> GetCategories(int startRec, int pageSize);
        DefSubCategory GetSubCategory(int categoryId);
        IListResult<DefSubCategory> GetSubCategories(int parentId, bool isParent = false);
        IDataResult<DefCategory> GetCategory(int categoryId);
        IListResult<DefCategory> GetCategories(int id = (int)StatusTypes.All);
        IListResult<CategoryListModel> GetSubCategories(int startRec, int pageSize);
        DefSubCategory AddSubCategory(DefSubCategory category);
        bool UpdateSubCategory(DefSubCategory category);
    }
}
