using Domain.OrderAggregates;

namespace EfCore.Services.Contracts
{
    public interface IOrderHeaderRepository
    {
        List<OrderHeader> GetOrderHeaders();
        void AddOrderHeader(OrderHeader orderHeader);
        void UpdateOrderHeader(OrderHeader orderHeader);
        void DeleteOrderHeader(Guid id);
        OrderHeader GetOrderHeader(Guid Id);
    }
}
