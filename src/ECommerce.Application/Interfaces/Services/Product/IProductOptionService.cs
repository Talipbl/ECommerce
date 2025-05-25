using Ecommerce.Shared.Utilities.Results;
using ECommerce.Systems;

namespace ECommerce.Product;

public interface IProductOptionService
{
    IDataResult<GnlProductOption> AddProductOption(GnlProductOption option);
    IResult UpdateProductOption(GnlProductOption option);
    IResult DeleteProductOption(int id);
    IListResult<GnlProductOption> GetAllProductOption();
    IListResult<GnlProductOption> GetProductOptions(int productId, int statusId = (int)StatusTypes.Active);
    IListResult<GnlProductOption> GetProductOption(int optionId);
}
