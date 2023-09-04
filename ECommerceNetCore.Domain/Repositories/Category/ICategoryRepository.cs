using ECommerce.Application.DataTransferObjects;
using ECommerce.Application.Utilities.Results.Abstracts;
using ECommerce.Domain.Common.Enumarations;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Interfaces.Repositories.Category
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
