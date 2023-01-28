using ApplicationService.Dtos.OrdersDtos.OrderDeatailDtos;
using ApplicationService.Dtos.PersonDtos;

namespace ApplicationService.Dtos.OrdersDtos.OrderHeaderDtos
{
    public class OrderHeader_Detail_Dto
    {
        public Guid ID { get; set; }
        public List<OrderDetail_Edit_Dto>? OrderDetail { get; set; }
        public Person_Edit_Dto? Seller { get; set; }
        public Person_Edit_Dto? Buyer { get; set; }
    }
}
