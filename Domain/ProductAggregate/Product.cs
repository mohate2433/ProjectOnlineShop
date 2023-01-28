using Domain.OrderAggregates;

namespace Domain.ProductAggregate
{
    public class Product
    {
        public Guid ID { get; set; }
        public string? Title { get; set; }
        public int UnitPrice { get; set; }
        public string? PictureAddress { get; set; }
        public string? PictureAlt { get; set; }
        public string? PictureTitle { get; set; }
        public string? ProductDescription { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsRemoved { get; set; }
        public List<OrderDetail>? OrderDetails { get; set; }

    }
}
