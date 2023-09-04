using ECommerce.Core.Application;
using ECommerce.Core.Persistance;
using ECommerce.Domain.Common.Enumarations;

namespace ECommerce.Category
{
    public interface ICategoryRepository : IBaseEntityRepository<DefCategory>
    {
        IListResult<DefCategory> GetCategories(int startRec, int pageSize);
        DefSubCategory GetSubCategory(int categoryId);
        IListResult<DefSubCategory> GetSubCategories(int parentId, bool isParent = false);
        IDataResult<DefCategory> GetCategory(int categoryId);
        IListResult<DefCategory> GetCategories(int id = (int)StatusTypes.All);
        IListResult<DefCategory> GetSubCategories(int startRec, int pageSize);
        DefSubCategory AddSubCategory(DefSubCategory category);
        bool UpdateSubCategory(DefSubCategory category);
    }
}
