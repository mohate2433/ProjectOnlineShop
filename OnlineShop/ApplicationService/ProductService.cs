using ApplicationService.Contracts;
using ApplicationService.Dtos.ProductDtos;
using Domain.ProductAggregate;
using EfCore.Services.Contracts;

namespace ApplicationService
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        private static List<Product_FillGrid_Dto> Convert(List<Product> products)
        {
            var dtoList = new List<Product_FillGrid_Dto>();
            for (int i = 0; i < products.Count; i++)
            {
                dtoList.Add(new Product_FillGrid_Dto());
                dtoList[i].Id = products[i].ID;
                dtoList[i].Title = products[i].Title;
                dtoList[i].PictureTitle = products[i].PictureTitle;
                dtoList[i].UnitPrice = products[i].UnitPrice;
                dtoList[i].ProductDescription = products[i].ProductDescription;
                dtoList[i].PictureAddress = products[i].PictureAddress;
                dtoList[i].PictureAlt = products[i].PictureAlt;
            }
            return dtoList;
        }
        private static Product Convert(Product_Save_Dto product_Save_Dto)
        {
            var product = new Product()
            {
                ID = new Guid(),
                Title = product_Save_Dto.Title,
                PictureTitle = product_Save_Dto.PictureTitle,
                UnitPrice = product_Save_Dto.UnitPrice,
                PictureAlt = product_Save_Dto.PictureAlt,
                PictureAddress = product_Save_Dto.PictureAddress,
                CreationDate = DateTime.Now,
                IsRemoved = false,
                ProductDescription = product_Save_Dto.ProductDescription
            };
            return product;
        }
        private static Product_Edit_Dto ConvertEdit(Product product)
        {
            var Product_Edit_Dto = new Product_Edit_Dto()
            {
                Id = product.ID,
                Title = product.Title,
                PictureTitle = product.PictureTitle,
                UnitPrice = product.UnitPrice,
                PictureAlt = product.PictureAlt,
                PictureAddress = product.PictureAddress,
                ProductDescription = product.ProductDescription
            };
            return Product_Edit_Dto;
        }
        private static Product_Detail_Dto Convert(Product product)
        {
            var product_Detail_Dto = new Product_Detail_Dto()
            {
                Id = product.ID,
                Title = product.Title,
                PictureTitle = product.PictureTitle,
                UnitPrice = product.UnitPrice,
                PictureAlt = product.PictureAlt,
                PictureAddress = product.PictureAddress,
                ProductDescription = product.ProductDescription
            };
            return product_Detail_Dto;
        }
        private static Product Convert(Product_Edit_Dto product_Edit_Dto)
        {
            var product = new Product()
            {
                Title = product_Edit_Dto.Title,
                PictureTitle = product_Edit_Dto.PictureTitle,
                UnitPrice = product_Edit_Dto.UnitPrice,
                PictureAlt = product_Edit_Dto.PictureAlt,
                PictureAddress = product_Edit_Dto.PictureAddress,
                ProductDescription = product_Edit_Dto.ProductDescription
            };
            return product;
        }

        public void Delete(Guid id) => _productRepository.DeleteProduct(id);

        public void Edit(Product_Edit_Dto product_Edit_Dto) => _productRepository.UpdateProduct(Convert(product_Edit_Dto));

        public List<Product_FillGrid_Dto> FillGrid() => ProductService.Convert(_productRepository.GetProducts());

        public void Save(Product_Save_Dto product_Save_Dto) => _productRepository.AddProduct(Convert(product_Save_Dto));

        public Product_Detail_Dto Find(Guid id) => Convert(_productRepository.GetProduct(id));

        public Product_Edit_Dto FindEdit(Guid id) => ConvertEdit(_productRepository.GetProduct(id));
    }
}
