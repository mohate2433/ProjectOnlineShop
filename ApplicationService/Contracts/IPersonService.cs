using ApplicationService.Dtos.PersonDtos;

namespace ApplicationService.Contracts
{
    public interface IPersonService
    {
        List<Person_FillGrid_Dto> FillGrid();
        void Save(Person_Save_Dto person_Save_Dto);
        Person_Detail_Dto Find(Guid id);
        Person_Edit_Dto FindEdit(Guid id);
        void Edit(Person_Edit_Dto person_Edit_Dto);
        void Delete(Guid id);
    }
}
