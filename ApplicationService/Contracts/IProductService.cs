using ApplicationService.Dtos.ProductDtos;

namespace ApplicationService.Contracts
{
    public interface IProductService
    {
        List<Product_FillGrid_Dto> FillGrid();
        void Save(Product_Save_Dto product_Save_Dto);
        Product_Detail_Dto Find(Guid id);
        Product_Edit_Dto FindEdit(Guid id);
        void Edit(Product_Edit_Dto product_Edit_Dto);
        void Delete(Guid id);

    }
}
