using Domain.OrderAggregates;
using Domain.PersonAggregates;
using Domain.ProductAggregate;
using Microsoft.EntityFrameworkCore;

namespace OnlineShop.Models
{
    public class OnlineShopDbContext : DbContext
    {
        public OnlineShopDbContext(DbContextOptions Options) : base(Options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetail>().HasKey(option => new { option.ProductID, option.OrderHeaderID });
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Person> Person { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<OrderHeader> OrderHeader { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
    }
}
