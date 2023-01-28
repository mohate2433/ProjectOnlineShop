using ApplicationService.Dtos.OrdersDtos.OrderHeaderDtos;
using ApplicationService.Dtos.ProductDtos;
using Domain.OrderAggregates;
using Domain.ProductAggregate;

namespace ApplicationService.Dtos.OrdersDtos.OrderDeatailDtos
{
    public class OrderDetail_FillGrid_Dto
    {
        public Guid ProductID { get; set; }
        public Guid OrderHeaderID { get; set; }
        public Product_FillGrid_Dto? Product { get; set; }
        public OrderHeader_FillGrid_Dto? OrderHeader { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
    }
}
