using ECommerceNetCore.Application.Interfaces;
using ECommerceNetCore.Application.Utilities;
using ECommerceNetCore.Domain.Entities;

namespace ECommerceNetCore.Application.Services
{
    public class OrderService : IOrderService
    {
        #region Order
        public IDataResult<GnlOrder> AddOrder(GnlOrder order)
        {
            throw new NotImplementedException();
        }

        public IResult DeleteOrder(int orderId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<GnlOrder> GetOrder(int orderId)
        {
            throw new NotImplementedException();
        }

        public IListResult<GnlOrder> GetOrders(int userId = 0, string orderCode = "", int carrierId = 0, int couponId = 0, int statusTypeId = 1)
        {
            throw new NotImplementedException();
        }

        public IResult UpdateOrder(GnlOrder order)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Order Product

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
        #endregion

        #region Order Payment
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
        #endregion
    }
}
