using ECommerce.Core.Application;

namespace ECommerce.Order;

public class OrderPaymentService : IOrderPaymentService
{
    public IDataResult<GnlOrderPayment> AddOrderPayment(GnlOrderPayment orderPayment)
    {
        throw new NotImplementedException();
    }

    public IResult DeleteOrderPayment(int orderPaymentId)
    {
        throw new NotImplementedException();
    }

    public IDataResult<GnlOrderPayment> GetOrderPayment(int orderPaymentId, int statusTypeId = 0)
    {
        throw new NotImplementedException();
    }

    public IListResult<GnlOrderPayment> GetOrderPayments(int orderId = 0, int statusTypeId = 4)
    {
        throw new NotImplementedException();
    }

    public IResult UpdateOrderPayment(GnlOrderPayment orderPayment)
    {
        throw new NotImplementedException();
    }
}
