using ApplicationService.Dtos.OrdersDtos.OrderHeaderDtos;

namespace ApplicationService.Contracts
{
    public interface IOrderHeaderService
    {
        List<OrderHeader_FillGrid_Dto> FillGrid();
        void Save(OrderHeader_Save_Dto orderHeader_Save_Dto);
        OrderHeader_Edit_Dto FindEdit(Guid id);
        OrderHeader_Detail_Dto Find(Guid id);
        void Edit(OrderHeader_Edit_Dto orderHeader_Edit_Dto);
        void Delete(Guid id);
    }
}
