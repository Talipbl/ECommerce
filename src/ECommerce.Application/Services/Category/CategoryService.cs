using Ecommerce.Shared.Utilities.Results;
using System.Net.WebSockets;

namespace ECommerce.Category;

public class CategoryService : ICategoryService
{
    //TO-DO: AutoMapper entegrasyonu yapılacak.
    ICategoryRepository CategoryRepo { get; }

    public CategoryService(ICategoryRepository categoryRepo)
    {
        CategoryRepo = categoryRepo;
    }
    public DefCategory AddCategory(DefCategory category)
    {
        return CategoryRepo.Add(category);
    }

    public IResult DeleteCategory(int categoryId)
    {
        throw new NotImplementedException();
    }

    public IListResult<DefCategory> GetCategories()
    {
        var result = CategoryRepo.GetCategories().ToList();
        return null;
    }

    public IDataResult<DefCategory> GetCategory(int categoryId)
    {
        var result = CategoryRepo.GetCategory(categoryId);

        return null;
    }

    public IResult UpdateCategory(DefCategory category)
    {
        var result = CategoryRepo.Update(category);
        return new Result(result);
    }
    public IListResult<DefCategory> GetCategories(int startRec, int pageSize)
    {
        var result = CategoryRepo.GetCategories();
        return null;
    }
}
