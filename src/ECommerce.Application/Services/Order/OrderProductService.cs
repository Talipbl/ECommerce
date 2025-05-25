using Ecommerce.Shared.Utilities.Results;

namespace ECommerce.Order;

public class OrderProductService : IOrderProductService
{
    public IDataResult<GnlOrderProduct> AddOrderProduct(GnlOrderProduct orderProduct)
    {
        throw new NotImplementedException();
    }

    public IResult DeleteOrderProduct(int orderProductId)
    {
        throw new NotImplementedException();
    }

    public IDataResult<GnlOrderProduct> GetOrderProduct(int orderProductId)
    {
        throw new NotImplementedException();
    }

    public IListResult<GnlOrderProduct> GetOrderProducts(int orderId = 0, int productId = 0)
    {
        throw new NotImplementedException();
    }

    public IResult UpdateOrderProduct(GnlOrderProduct orderProduct)
    {
        throw new NotImplementedException();
    }
}