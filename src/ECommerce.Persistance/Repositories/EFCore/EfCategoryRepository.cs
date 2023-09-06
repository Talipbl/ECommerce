using ECommerce.Core.Persistance;
using ECommerce.Persistance;
using Microsoft.Data.SqlClient;

namespace ECommerce.Category;

public class EfCategoryRepository : EfBaseEntityRepository<DefCategory, ECommerceContext>, ICategoryRepository
{
    public DefSubCategory AddSubCategory(DefSubCategory category)
    {
        return Add(category);
    }

    public ICollection<DefCategory> GetCategories(int id = 0)
    {
        var result = GetAll<DefCategory>(x => id != 0 ? x.Id == id : x.Id != id).ToList();
        return result;
    }

    public ICollection<DefCategory> GetCategories(int startRec, int pageSize)
    {
        var result = GetAll(null, x => x.Id, (int)SortOrder.Descending, startRec, pageSize).ToList();
        var count = GetCount();

        return result;
    }

    public DefCategory GetCategory(int categoryId)
    {
        var result = Get(x => x.Id == categoryId);
        return result;
    }

    public ICollection<DefSubCategory> GetSubCategories(int parentId, bool isParent = false)
    {
        var result = GetAll<DefSubCategory>(x => x.ParentId == parentId && x.IsParent == isParent).ToList();
        return result;
    }

    public ICollection<DefSubCategory> GetSubCategories(int startRec, int pageSize)
    {
        var result = GetAll<int, DefSubCategory>(null, x => x.ParentId, (int)SortOrder.Ascending, startRec, pageSize).Select(x => new DefSubCategory()
        {
            Id = x.Id,
            CategoryName = x.CategoryName,
            Description = x.Description,
            IsParent = x.IsParent
        }).ToList();
        var count = GetCount<DefSubCategory>();

        return result;
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
