using ECommerce.Core.Persistance;

namespace ECommerce.Category
{
    public interface ICategoryRepository : IBaseEntityRepository<DefCategory>
    {
        ICollection<DefCategory> GetCategories(int startRec, int pageSize);
        DefSubCategory GetSubCategory(int categoryId);
        ICollection<DefSubCategory> GetSubCategories(int parentId, bool isParent = false);
        DefCategory GetCategory(int categoryId);
        ICollection<DefCategory> GetCategories(int id = 0);
        ICollection<DefSubCategory> GetSubCategories(int startRec, int pageSize);
        DefSubCategory AddSubCategory(DefSubCategory category);
        bool UpdateSubCategory(DefSubCategory category);
    }
}
