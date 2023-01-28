using ApplicationService.Dtos.OrdersDtos.OrderDeatailDtos;
using ApplicationService.Dtos.PersonDtos;

namespace ApplicationService.Dtos.OrdersDtos.OrderHeaderDtos
{
    public class OrderHeader_FillGrid_Dto
    {
        public Guid ID { get; set; }
        public List<OrderDetail_FillGrid_Dto>? OrderDetail_FillGrid_Dtos { get; set; }
        public Person_FillGrid_Dto? Seller { get; set; }
        public Person_FillGrid_Dto? Buyer { get; set; }
    }
}
