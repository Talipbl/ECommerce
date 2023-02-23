using ECommerceNetCore.Application.Results;
using ECommerceNetCore.Domain.Common;
using ECommerceNetCore.Domain.Entities;

namespace ECommerceNetCore.Application.Interfaces
{
    public interface ICategoryRepository : IBaseEntityRepository<DefCategory>
    {
        IListResult<DefSubCategory> GetSubCategories(int parentId, bool isParent = false);
        IListResult<DefCategory> GetCategories(int id = (int)StatusTypes.All);
    }
}
