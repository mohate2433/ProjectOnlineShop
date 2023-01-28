using ApplicationService.Dtos.OrdersDtos.OrderDeatailDtos;
using ApplicationService.Dtos.PersonDtos;

namespace ApplicationService.Dtos.OrdersDtos.OrderHeaderDtos
{
    public class OrderHeader_Save_Dto
    {
        public List<OrderDetail_Detail_Dto>? orderDetail_Detail_Dtos { get; set; }
        public Person_Detail_Dto? Seller { get; set; }
        public Person_Detail_Dto? Buyer { get; set; }
    }
}
