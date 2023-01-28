using ApplicationService.Contracts;
using ApplicationService.Dtos.PersonDtos;
using Domain.PersonAggregates;
using EfCore.Services.Contracts;

namespace ApplicationService
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        private static List<Person_FillGrid_Dto> Convert(List<Person> person)
        {
            var dtoList = new List<Person_FillGrid_Dto>();
            for (int i = 0; i < person.Count; i++)
            {
                dtoList.Add(new Person_FillGrid_Dto());
                dtoList[i].Id = person[i].Id;
                dtoList[i].FirstName = person[i].FirstName;
                dtoList[i].LastName = person[i].LastName;
            }
            return dtoList;
        }

        private static Person Convert(Person_Save_Dto person_Save_Dto)
        {
            var person = new Person()
            {
                Id = new Guid(),
                FirstName = person_Save_Dto.FirstName,
                LastName = person_Save_Dto.LastName
            };
            return person;
        }

        private static Person Convert(Person_Edit_Dto person_Edit_Dto)
        {
            var Person = new Person()
            {
                Id = person_Edit_Dto.Id,
                FirstName = person_Edit_Dto.FirstName,
                LastName = person_Edit_Dto.LastName
            };
            return Person;
        }

        private static Person_Detail_Dto Convert(Person person)
        {
            var person_Detail_Dto = new Person_Detail_Dto()
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName
            };
            return person_Detail_Dto;
        }

        private static Person_Edit_Dto ConvertEdit(Person person)
        {
            var person_Edit_Dto = new Person_Edit_Dto()
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName
            };
            return person_Edit_Dto;
        }

        public void Delete(Guid id) => _personRepository.DeletePerson(id);

        public void Edit(Person_Edit_Dto person_Edit_Dto) => _personRepository.UpdatePerson(Convert(person_Edit_Dto));

        public List<Person_FillGrid_Dto> FillGrid() => PersonService.Convert(_personRepository.GetPeople());

        public Person_Detail_Dto Find(Guid id) => Convert(_personRepository.GetPerson(id));

        public Person_Edit_Dto FindEdit(Guid id) => ConvertEdit(_personRepository.GetPerson(id));

        public void Save(Person_Save_Dto person_Save_Dto) => _personRepository.AddPerson(Convert(person_Save_Dto));
    }
}
