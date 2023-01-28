using Domain.PersonAggregates;

namespace Domain.OrderAggregates
{
    public class OrderHeader
    {
        public Guid ID { get; set; }
        public List<OrderDetail>? OrderDetails { get; set; }
        public Person? Seller { get; set; }
        public Person? Buyer { get; set; }
    }
}
