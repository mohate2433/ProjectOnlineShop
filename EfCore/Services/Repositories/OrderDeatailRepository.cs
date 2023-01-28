using Domain.OrderAggregates;
using EfCore.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Models;

namespace EfCore.Services.Repositories
{
    public class OrderDeatailRepository : IOrderDetailRepository
    {
        private readonly OnlineShopDbContext _context;

        public OrderDeatailRepository(OnlineShopDbContext context)
        {
            _context = context;
        }

        public void AddOrderDeatail(OrderDetail orderDetail)
        {
            using (_context)
            {
                try
                {
                    _context.OrderDetail.Add(orderDetail);
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    _context.Dispose();
                }
            }
        }

        public void DeleteOrderDeatail(Guid productID , Guid orderHeaderID)
        {
            using (_context)
            {
                try
                {
                    var orderDetail = _context.OrderDetail.FirstOrDefault(x => x.ProductID == productID && x.OrderHeaderID == orderHeaderID);
                    _context.Entry(orderDetail).State = EntityState.Deleted;
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    _context.Dispose();
                }
            }
        }

        public List<OrderDetail> GetOrderDeatails()
        {
            using (_context)
            {
                try
                {
                    return _context.OrderDetail.ToList();
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    _context.Dispose();
                }
            }
        }

        public OrderDetail GetOrderDeatail(Guid productID, Guid orderHeaderID)
        {
            using (_context)
            {
                try
                {
                    return _context.OrderDetail.FirstOrDefault(f=>f.ProductID == productID && f.OrderHeaderID == orderHeaderID);
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    _context.Dispose();
                }
            }
        }

        public void UpdateOrderDeatail(OrderDetail orderDetail)
        {
            using (_context)
            {
                try
                {
                    _context.Entry(orderDetail).State = EntityState.Modified;
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    _context.Dispose();
                }
            }
        }
    }
}
