using ApplicationService.Dtos.OrdersDtos.OrderHeaderDtos;
using ApplicationService.Dtos.ProductDtos;

namespace ApplicationService.Dtos.OrdersDtos.OrderDeatailDtos
{
    public class OrderDetail_Detail_Dto
    {
        public Guid ProductID { get; set; }
        public Guid OrderHeaderID { get; set; }
        public Product_Detail_Dto? Product { get; set; }
        public OrderHeader_Detail_Dto? OrderHeader { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
    }
}
