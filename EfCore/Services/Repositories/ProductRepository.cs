using Domain.ProductAggregate;
using EfCore.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Models;

namespace EfCore.Services.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly OnlineShopDbContext _context;

        public ProductRepository(OnlineShopDbContext context)
        {
            _context = context;
        }

        public void AddProduct(Product product)
        {
            using (_context)
            {
                try
                {
                    _context.Product.Add(product);
                    _context.SaveChanges();
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

        public void DeleteProduct(Guid id)
        {
            using (_context)
            {
                try
                {
                    var product = _context.Product.FirstOrDefault(x => x.ID == id);
                    if (product != null)
                    {
                        _context.Remove(product);
                        _context.SaveChanges();
                    }
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

        public Product GetProduct(Guid Id)
        {
            using (_context)
            {
                try
                {
                    return _context.Product.Find(Id);
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

        public List<Product> GetProducts()
        {
            using (_context)
            {
                try
                {
                    return _context.Product.ToList();
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

        public void UpdateProduct(Product product)
        {
            using (_context)
            {
                try
                {
                    _context.Entry(product).State = EntityState.Modified;
                    _context.SaveChanges();
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
