using ApplicationService.Dtos.OrdersDtos.OrderDeatailDtos;
using ApplicationService.Dtos.PersonDtos;

namespace ApplicationService.Dtos.OrdersDtos.OrderHeaderDtos
{
    public class OrderHeader_Delete_Dto
    {
        public List<OrderDetail_Delete_Dto>? OrderDetail_Delete_Dto { get; set; }
        public Perosn_Delete_Dto? Seller { get; set; }
        public Perosn_Delete_Dto? Buyer { get; set; }
    }
}
