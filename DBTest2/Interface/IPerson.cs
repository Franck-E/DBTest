namespace DBTest2;

using System.Collections.Generic;
using System.Threading.Tasks;

public interface IPerson
{
    Task<bool> HasData();
    Task EnsurePersonStore();
    Task<List<Person>> GetPersons();
    Task AddPerson(Person person);
    Task UpdatePerson(Person person);
    Task SavePerson(Person person);
    Task RemovePerson(Person person);
}