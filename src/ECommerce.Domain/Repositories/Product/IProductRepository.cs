using ECommerce.Core.Persistence;

namespace ECommerce.Product
{
    public interface IProductRepository : IBaseEntityRepository<GnlProduct>
    {
        GnlProduct GetProduct(string productName);
        GnlProduct GetProduct(int productId);
        ICollection<GnlProduct> GetProducts(int categoryId = 0, int brandId = 0, int manufacturerId = 0, int xmlId = 0, int statusId = 1, int start = 0, int take = 25);
    }
}
