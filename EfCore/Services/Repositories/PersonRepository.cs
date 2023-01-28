using Domain.PersonAggregates;
using EfCore.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Models;

namespace EfCore.Services.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly OnlineShopDbContext _context;

        public PersonRepository(OnlineShopDbContext context)
        {
            _context = context;
        }

        public void AddPerson(Person person)
        {
            using (_context)
            {
                try
                {
                    _context.Person.Add(person);
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

        public void DeletePerson(Guid id)
        {
            using (_context)
            {
                try
                {
                    var person = _context.Person.FirstOrDefault(x => x.Id == id);
                    if (person != null)
                    {
                        _context.Remove(person);
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

        public List<Person> GetPeople()
        {
            using (_context)
            {
                try
                {
                    
                    return _context.Person.ToList();
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

        public Person GetPerson(Guid id)
        {
            using (_context)
            {
                try
                {
                    return _context.Person.Find(id);
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

        public void UpdatePerson(Person person)
        {
            using (_context)
            {
                try
                {
                    _context.Entry(person).State = EntityState.Modified;
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
