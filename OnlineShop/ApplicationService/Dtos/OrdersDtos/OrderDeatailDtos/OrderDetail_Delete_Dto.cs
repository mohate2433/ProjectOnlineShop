using ApplicationService.Dtos.OrdersDtos.OrderHeaderDtos;
using ApplicationService.Dtos.ProductDtos;

namespace ApplicationService.Dtos.OrdersDtos.OrderDeatailDtos
{
    public class OrderDetail_Delete_Dto
    {
        public Product_Delete_Dto? Product_Delete_Dto { get; set; }
        public OrderHeader_Delete_Dto? OrderHeader_Delete_Dto { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
    }
}
