using ApplicationService.Contracts;
using ApplicationService.Dtos.OrdersDtos.OrderDeatailDtos;
using ApplicationService.Dtos.OrdersDtos.OrderHeaderDtos;
using Domain.OrderAggregates;
using EfCore.Services.Contracts;

namespace ApplicationService
{
    public class OrderHeaderService : IOrderHeaderService
    {
        private readonly IOrderHeaderRepository _orderHeaderRepository;

        public OrderHeaderService(IOrderHeaderRepository orderHeaderRepository)
        {
            _orderHeaderRepository = orderHeaderRepository;
        }
        private static List<OrderHeader_FillGrid_Dto> Convert(List<OrderHeader> orderHeaders)
        {
            var dtoDetail = new List<OrderDetail_Edit_Dto>();
            var dtoList = new List<OrderHeader_FillGrid_Dto>();
            for (int i = 0; i < orderHeaders.Count; i++)
            {
                dtoList.Add(new OrderHeader_FillGrid_Dto());
                dtoList[i].ID = orderHeaders[i].ID;
                dtoList[i].Seller.Id = orderHeaders[i].Seller.Id;
                dtoList[i].Seller.FirstName = orderHeaders[i].Seller.FirstName;
                dtoList[i].Seller.LastName = orderHeaders[i].Seller.LastName;
                dtoList[i].Buyer.Id = orderHeaders[i].Buyer.Id;
                dtoList[i].Buyer.FirstName = orderHeaders[i].Buyer.FirstName;
                dtoList[i].Buyer.LastName = orderHeaders[i].Buyer.LastName;
                foreach (var item in orderHeaders[i].OrderDetails)
                {              
                    dtoDetail[i].OrderHeaderID = item.OrderHeaderID;
                    dtoDetail[i].ProductID = item.ProductID;
                    dtoDetail[i].UnitPrice = item.UnitPrice;
                    dtoDetail[i].Quantity = item.Quantity;

                }
                foreach (var item in dtoList[i].OrderDetail_FillGrid_Dtos)
                {
                    item.OrderHeaderID = dtoDetail[i].OrderHeaderID;
                    item.ProductID = dtoDetail[i].ProductID;
                    item.UnitPrice = dtoDetail[i].UnitPrice;
                    item.Quantity = dtoDetail[i].Quantity;
                }
            }
            return dtoList;
        }
        private static OrderHeader_Edit_Dto ConvertEdit(OrderHeader orderHeader)
        {
            var dtoDetail = new OrderDetail_Edit_Dto();
            var dto = new OrderHeader_Edit_Dto();
            dto.ID = orderHeader.ID;
            dto.Seller.Id = orderHeader.Seller.Id;
            dto.Seller.FirstName = orderHeader.Seller.FirstName;
            dto.Seller.LastName = orderHeader.Seller.LastName;
            dto.Buyer.Id = orderHeader.Buyer.Id;
            dto.Buyer.FirstName = orderHeader.Buyer.FirstName;
            dto.Buyer.LastName = orderHeader.Buyer.LastName;
            foreach (var item in orderHeader.OrderDetails)
            {          
                dtoDetail.OrderHeaderID = item.OrderHeaderID;
                dtoDetail.ProductID = item.ProductID;
                dtoDetail.UnitPrice = item.UnitPrice;
                dtoDetail.Quantity = item.Quantity;
                
            }
            foreach (var item in dto.OrderDetail)
            {
                item.OrderHeaderID = dtoDetail.OrderHeaderID;
                item.ProductID = dtoDetail.ProductID;
                item.UnitPrice = dtoDetail.UnitPrice;
                item.Quantity = dtoDetail.Quantity;
            }
            return dto;

        }
        private static OrderHeader_Detail_Dto Convert(OrderHeader orderHeader)
        {
            var dtoDetail = new OrderDetail_Edit_Dto();
            var dto = new OrderHeader_Detail_Dto();
            dto.ID = orderHeader.ID;
            dto.Seller.Id = orderHeader.Seller.Id;
            dto.Seller.FirstName = orderHeader.Seller.FirstName;
            dto.Seller.LastName = orderHeader.Seller.LastName;
            dto.Buyer.Id = orderHeader.Buyer.Id;
            dto.Buyer.FirstName = orderHeader.Buyer.FirstName;
            dto.Buyer.LastName = orderHeader.Buyer.LastName;
            //dto.OrderDetail.Select(s => s.ProductID && s.OrderHeaderID) = orderHeader.OrderDetails.Select(o => o.ProductID && o.OrderHeaderID)
            foreach (var item in orderHeader.OrderDetails)
            {          
                dtoDetail.OrderHeaderID = item.OrderHeaderID;
                dtoDetail.ProductID = item.ProductID;
                dtoDetail.UnitPrice = item.UnitPrice;
                dtoDetail.Quantity = item.Quantity;
                
            }
            foreach (var item in dto.OrderDetail)
            {
                item.OrderHeaderID = dtoDetail.OrderHeaderID;
                item.ProductID = dtoDetail.ProductID;
                item.UnitPrice = dtoDetail.UnitPrice;
                item.Quantity = dtoDetail.Quantity;
            }
            return dto;

        }
        private static OrderHeader Convert(OrderHeader_Edit_Dto orderHeader_Edit_Dto)
        {
            var dtoDetail = new OrderDetail();
            var dto = new OrderHeader();
            dto.ID = orderHeader_Edit_Dto.ID;
            dto.Seller.Id = orderHeader_Edit_Dto.Seller.Id;
            dto.Seller.FirstName = orderHeader_Edit_Dto.Seller.FirstName;
            dto.Seller.LastName = orderHeader_Edit_Dto.Seller.LastName;
            dto.Buyer.Id = orderHeader_Edit_Dto.Buyer.Id;
            dto.Buyer.FirstName = orderHeader_Edit_Dto.Buyer.FirstName;
            dto.Buyer.LastName = orderHeader_Edit_Dto.Buyer.LastName;
            foreach (var item in orderHeader_Edit_Dto.OrderDetail)
            {
                dtoDetail.OrderHeaderID = item.OrderHeaderID;
                dtoDetail.ProductID = item.ProductID;
                dtoDetail.UnitPrice = item.UnitPrice;
                dtoDetail.Quantity = item.Quantity;

            }
            foreach (var item in dto.OrderDetails)
            {
                item.OrderHeaderID = dtoDetail.OrderHeaderID;
                item.ProductID = dtoDetail.ProductID;
                item.UnitPrice = dtoDetail.UnitPrice;
                item.Quantity = dtoDetail.Quantity;
            }
            return dto;
        }
        
        private static OrderHeader Convert(OrderHeader_Save_Dto orderHeader_Save_Dto)
        {
            var dtoDetail = new OrderDetail();
            var dto = new OrderHeader();
            dto.ID = new Guid();
            dto.Seller.Id = orderHeader_Save_Dto.Seller.Id;
            dto.Seller.FirstName = orderHeader_Save_Dto.Seller.FirstName;
            dto.Seller.LastName = orderHeader_Save_Dto.Seller.LastName;
            dto.Buyer.Id = orderHeader_Save_Dto.Buyer.Id;
            dto.Buyer.FirstName = orderHeader_Save_Dto.Buyer.FirstName;
            dto.Buyer.LastName = orderHeader_Save_Dto.Buyer.LastName;
            foreach (var item in orderHeader_Save_Dto.orderDetail_Detail_Dtos)
            {
                dtoDetail.OrderHeaderID = item.OrderHeaderID;
                dtoDetail.ProductID = item.ProductID;
                dtoDetail.UnitPrice = item.UnitPrice;
                dtoDetail.Quantity = item.Quantity;

            }
            foreach (var item in dto.OrderDetails)
            {
                item.OrderHeaderID = dtoDetail.OrderHeaderID;
                item.ProductID = dtoDetail.ProductID;
                item.UnitPrice = dtoDetail.UnitPrice;
                item.Quantity = dtoDetail.Quantity;
            }
            return dto;
        }

        public List<OrderHeader_FillGrid_Dto> FillGrid() => OrderHeaderService.Convert(_orderHeaderRepository.GetOrderHeaders());

        public void Save(OrderHeader_Save_Dto orderHeader_Save_Dto) => _orderHeaderRepository.AddOrderHeader(Convert(orderHeader_Save_Dto));

        public OrderHeader_Edit_Dto FindEdit(Guid id) => ConvertEdit(_orderHeaderRepository.GetOrderHeader(id));

        public OrderHeader_Detail_Dto Find(Guid id) => Convert(_orderHeaderRepository.GetOrderHeader(id));

        public void Edit(OrderHeader_Edit_Dto orderHeader_Edit_Dto) => _orderHeaderRepository.UpdateOrderHeader(Convert(orderHeader_Edit_Dto));

        public void Delete(Guid id) => _orderHeaderRepository.DeleteOrderHeader(id);
    }
}
