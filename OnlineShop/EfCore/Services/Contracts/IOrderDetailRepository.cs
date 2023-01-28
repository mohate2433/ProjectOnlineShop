using Domain.OrderAggregates;

namespace EfCore.Services.Contracts
{
    public interface IOrderDetailRepository
    {
        List<OrderDetail> GetOrderDeatails();
        void AddOrderDeatail(OrderDetail orderDetail);
        void UpdateOrderDeatail(OrderDetail orderDetail);
        void DeleteOrderDeatail(Guid productID, Guid orderHeaderID);
        OrderDetail GetOrderDeatail(Guid productID , Guid orderHeaderID);
    }
}
