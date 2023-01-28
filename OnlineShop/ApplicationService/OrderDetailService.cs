using ApplicationService.Contracts;
using ApplicationService.Dtos.OrdersDtos.OrderDeatailDtos;
using ApplicationService.Dtos.OrdersDtos.OrderHeaderDtos;
using ApplicationService.Dtos.ProductDtos;
using Domain.OrderAggregates;
using EfCore.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderDetailService(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        private static List<OrderDetail_FillGrid_Dto> Convert(List<OrderDetail> orderDetails)
        {
            var dtoList = new List<OrderDetail_FillGrid_Dto>();
            for (int i = 0; i < orderDetails.Count; i++)
            {
                dtoList.Add(new OrderDetail_FillGrid_Dto());
                dtoList[i].UnitPrice = orderDetails[i].UnitPrice;
                dtoList[i].Quantity = orderDetails[i].Quantity;
                dtoList[i].ProductID =orderDetails[i].ProductID;
                dtoList[i].OrderHeaderID =orderDetails[i].OrderHeaderID;
                dtoList[i].Product.ProductDescription = orderDetails[i].Product.ProductDescription;
                dtoList[i].Product.PictureTitle = orderDetails[i].Product.PictureTitle ;
                dtoList[i].Product.PictureAddress = orderDetails[i].Product.PictureAddress ;
                dtoList[i].Product.PictureAlt = orderDetails[i].Product.PictureAlt;
                dtoList[i].Product.Id = orderDetails[i].Product.ID;
                dtoList[i].Product.Title = orderDetails[i].Product.Title;
                dtoList[i].Product.UnitPrice = orderDetails[i].Product.UnitPrice;
                dtoList[i].OrderHeader.ID = orderDetails[i].OrderHeader.ID;
                dtoList[i].OrderHeader.Buyer.Id = orderDetails[i].OrderHeader.Buyer.Id;
                dtoList[i].OrderHeader.Buyer.FirstName = orderDetails[i].OrderHeader.Buyer.FirstName;
                dtoList[i].OrderHeader.Buyer.LastName = orderDetails[i].OrderHeader.Buyer.LastName;
                dtoList[i].OrderHeader.Seller.Id = orderDetails[i].OrderHeader.Seller.Id;
                dtoList[i].OrderHeader.Seller.FirstName = orderDetails[i].OrderHeader.Seller.FirstName;
                dtoList[i].OrderHeader.Seller.LastName = orderDetails[i].OrderHeader.Seller.LastName;
            }
            return dtoList;
        }

        private static OrderDetail_Edit_Dto ConvertEdit(OrderDetail orderDetail)
        {
            var dto = new OrderDetail_Edit_Dto();
            dto.UnitPrice = orderDetail.UnitPrice;
            dto.Quantity = orderDetail.Quantity;
            dto.ProductID = orderDetail.ProductID;
            dto.OrderHeaderID = orderDetail.OrderHeaderID;
            dto.Product.ProductDescription = orderDetail.Product.ProductDescription;
            dto.Product.PictureTitle = orderDetail.Product.PictureTitle;
            dto.Product.PictureAddress = orderDetail.Product.PictureAddress;
            dto.Product.PictureAlt = orderDetail.Product.PictureAlt;
            dto.Product.Id = orderDetail.Product.ID;
            dto.Product.Title = orderDetail.Product.Title;
            dto.Product.UnitPrice = orderDetail.Product.UnitPrice;
            dto.OrderHeader.ID = orderDetail.OrderHeader.ID;
            dto.OrderHeader.Buyer.Id = orderDetail.OrderHeader.Buyer.Id;
            dto.OrderHeader.Buyer.FirstName = orderDetail.OrderHeader.Buyer.FirstName;
            dto.OrderHeader.Buyer.LastName = orderDetail.OrderHeader.Buyer.LastName;
            dto.OrderHeader.Seller.Id = orderDetail.OrderHeader.Seller.Id;
            dto.OrderHeader.Seller.FirstName = orderDetail.OrderHeader.Seller.FirstName;
            dto.OrderHeader.Seller.LastName = orderDetail.OrderHeader.Seller.LastName;
            return dto;
        }
        private static OrderDetail_Detail_Dto Convert(OrderDetail orderDetail)
        {
            var dto = new OrderDetail_Detail_Dto();
            dto.UnitPrice = orderDetail.UnitPrice;
            dto.Quantity = orderDetail.Quantity;
            dto.ProductID = orderDetail.ProductID;
            dto.OrderHeaderID = orderDetail.OrderHeaderID;
            dto.Product.ProductDescription = orderDetail.Product.ProductDescription;
            dto.Product.PictureTitle = orderDetail.Product.PictureTitle;
            dto.Product.PictureAddress = orderDetail.Product.PictureAddress;
            dto.Product.PictureAlt = orderDetail.Product.PictureAlt;
            dto.Product.Id = orderDetail.Product.ID;
            dto.Product.Title = orderDetail.Product.Title;
            dto.Product.UnitPrice = orderDetail.Product.UnitPrice;
            dto.OrderHeader.ID = orderDetail.OrderHeader.ID;
            dto.OrderHeader.Buyer.Id = orderDetail.OrderHeader.Buyer.Id;
            dto.OrderHeader.Buyer.FirstName = orderDetail.OrderHeader.Buyer.FirstName;
            dto.OrderHeader.Buyer.LastName = orderDetail.OrderHeader.Buyer.LastName;
            dto.OrderHeader.Seller.Id = orderDetail.OrderHeader.Seller.Id;
            dto.OrderHeader.Seller.FirstName = orderDetail.OrderHeader.Seller.FirstName;
            dto.OrderHeader.Seller.LastName = orderDetail.OrderHeader.Seller.LastName;
            return dto;
        }

        private static OrderDetail Convert(OrderDetail_Save_Dto orderDetail_Save_Dto)
        {
            var dto = new OrderDetail();
            dto.ProductID = orderDetail_Save_Dto.Product.Id;
            dto.OrderHeaderID = orderDetail_Save_Dto.OrderHeader.ID;
            dto.Quantity = orderDetail_Save_Dto.Quantity;
            dto.UnitPrice = orderDetail_Save_Dto.UnitPrice;
            dto.Product.ID = orderDetail_Save_Dto.Product.Id;
            dto.Product.Title = orderDetail_Save_Dto.Product.Title;
            dto.Product.UnitPrice = orderDetail_Save_Dto.Product.UnitPrice;
            dto.Product.PictureAddress = orderDetail_Save_Dto.Product.PictureAddress;
            dto.Product.ProductDescription = orderDetail_Save_Dto.Product.ProductDescription;
            dto.Product.PictureTitle = orderDetail_Save_Dto.Product.PictureTitle;
            dto.Product.PictureAlt = orderDetail_Save_Dto.Product.PictureAlt;
            dto.OrderHeader.ID = orderDetail_Save_Dto.OrderHeader.ID;
            dto.OrderHeader.Buyer.Id = orderDetail_Save_Dto.OrderHeader.Buyer.Id;
            dto.OrderHeader.Buyer.FirstName = orderDetail_Save_Dto.OrderHeader.Buyer.FirstName;
            dto.OrderHeader.Buyer.LastName = orderDetail_Save_Dto.OrderHeader.Buyer.LastName;
            dto.OrderHeader.Seller.Id = orderDetail_Save_Dto.OrderHeader.Seller.Id;
            dto.OrderHeader.Seller.FirstName = orderDetail_Save_Dto.OrderHeader.Seller.FirstName;
            dto.OrderHeader.Seller.LastName = orderDetail_Save_Dto.OrderHeader.Seller.LastName;
            return dto;
        }
        private static OrderDetail Convert(OrderDetail_Edit_Dto orderDetail_Edit_Dto)
        {
            var dto = new OrderDetail();
            dto.ProductID = orderDetail_Edit_Dto.Product.Id;
            dto.OrderHeaderID = orderDetail_Edit_Dto.OrderHeader.ID;
            dto.Quantity = orderDetail_Edit_Dto.Quantity;
            dto.UnitPrice = orderDetail_Edit_Dto.UnitPrice;
            dto.Product.ID = orderDetail_Edit_Dto.Product.Id;
            dto.Product.Title = orderDetail_Edit_Dto.Product.Title;
            dto.Product.UnitPrice = orderDetail_Edit_Dto.Product.UnitPrice;
            dto.Product.PictureAddress = orderDetail_Edit_Dto.Product.PictureAddress;
            dto.Product.ProductDescription = orderDetail_Edit_Dto.Product.ProductDescription;
            dto.Product.PictureTitle = orderDetail_Edit_Dto.Product.PictureTitle;
            dto.Product.PictureAlt = orderDetail_Edit_Dto.Product.PictureAlt;
            dto.OrderHeader.ID = orderDetail_Edit_Dto.OrderHeader.ID;
            dto.OrderHeader.Buyer.Id = orderDetail_Edit_Dto.OrderHeader.Buyer.Id;
            dto.OrderHeader.Buyer.FirstName = orderDetail_Edit_Dto.OrderHeader.Buyer.FirstName;
            dto.OrderHeader.Buyer.LastName = orderDetail_Edit_Dto.OrderHeader.Buyer.LastName;
            dto.OrderHeader.Seller.Id = orderDetail_Edit_Dto.OrderHeader.Seller.Id;
            dto.OrderHeader.Seller.FirstName = orderDetail_Edit_Dto.OrderHeader.Seller.FirstName;
            dto.OrderHeader.Seller.LastName = orderDetail_Edit_Dto.OrderHeader.Seller.LastName;
            return dto;
        }

        public void Delete(Guid productID, Guid orderHeaderID) => _orderDetailRepository.DeleteOrderDeatail(productID, orderHeaderID);

        public void Edit(OrderDetail_Edit_Dto orderDetail_Edit_Dto) => _orderDetailRepository.UpdateOrderDeatail(Convert(orderDetail_Edit_Dto));

        public List<OrderDetail_FillGrid_Dto> FillGrid() => OrderDetailService.Convert(_orderDetailRepository.GetOrderDeatails());

        public OrderDetail_Detail_Dto Find(Guid productID, Guid orderHeaderID) => Convert(_orderDetailRepository.GetOrderDeatail(productID, orderHeaderID));

        public OrderDetail_Edit_Dto FindEdit(Guid productID, Guid orderHeaderID) => ConvertEdit(_orderDetailRepository.GetOrderDeatail(productID, orderHeaderID));

        public void Save(OrderDetail_Save_Dto orderDetail_Save_Dto) => _orderDetailRepository.AddOrderDeatail(Convert(orderDetail_Save_Dto));
    }
}
