using ECommerce.Core.Application;

namespace ECommerce.Order
{
    public interface IOrderProductService
    {
        IDataResult<GnlOrderProduct> AddOrderProduct(GnlOrderProduct orderProduct);
        IResult UpdateOrderProduct(GnlOrderProduct orderProduct);
        IResult DeleteOrderProduct(int orderProductId);
        IListResult<GnlOrderProduct> GetOrderProducts(int orderId = 0, int productId = 0);
        IDataResult<GnlOrderProduct> GetOrderProduct(int orderProductId);
    }
}
