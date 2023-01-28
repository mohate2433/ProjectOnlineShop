using ApplicationService.Dtos.OrdersDtos.OrderDeatailDtos;

namespace ApplicationService.Contracts
{
    public interface IOrderDetailService
    {
        List<OrderDetail_FillGrid_Dto> FillGrid();
        void Save(OrderDetail_Save_Dto orderDetail_Save_Dto);
        OrderDetail_Edit_Dto FindEdit(Guid productID, Guid orderHeaderID);
        OrderDetail_Detail_Dto Find(Guid productID , Guid orderHeaderID);
        void Edit(OrderDetail_Edit_Dto orderDetail_Edit_Dto);
        void Delete(Guid productID, Guid orderHeaderID);
    }
}
