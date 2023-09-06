using ECommerce.Core.Application;
using ECommerce.Core.Persistance;
using ECommerce.Systems;

namespace ECommerce.Category
{
    public interface ICategoryRepository : IBaseEntityRepository<DefCategory>
    {
        ICollection<DefCategory> GetCategories(int startRec, int pageSize);
        DefSubCategory GetSubCategory(int categoryId);
        ICollection<DefSubCategory> GetSubCategories(int parentId, bool isParent = false);
        DefCategory GetCategory(int categoryId);
        ICollection<DefCategory> GetCategories(int id = (int)StatusTypes.All);
        DefSubCategory AddSubCategory(DefSubCategory category);
        bool UpdateSubCategory(DefSubCategory category);
    }
}
