using Domain.ProductAggregate;

namespace EfCore.Services.Contracts
{
    public interface IProductRepository
    {
        List<Product> GetProducts();
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Guid id);
        Product GetProduct(Guid Id);
    }
}
