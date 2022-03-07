using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBTest2;

public class StorePerson : IPerson
{
    protected DataDBContext dBContext;
    public StorePerson(DataDBContext dBContext)
    {
        this.dBContext = dBContext;
    }
    public async Task AddPerson(Person person)
    {
        dBContext.PersonData.Add(person);
        await dBContext.SaveChangesAsync();
    }

    public async Task EnsurePersonStore()
    {
        try
        {
            await dBContext.Database.EnsureCreatedAsync();
        }
        catch (Exception e) { e.Message.ToString(); }

        try
        {
            //await dBContext.Database.MigrateAsync();
        }
        catch (Exception) { }
    }

    public Task<List<Person>> GetPersons()
    {
        return Task.FromResult(dBContext.PersonData.ToList());
    }

    public async Task<bool> HasData()
    {
        return dBContext.PersonData.Count() > 0;
    }

    public async Task RemovePerson(Person person)
    {
        dBContext.PersonData.Remove(person);
        await dBContext.SaveChangesAsync();
    }

    public async Task SavePerson(Person person)
    {
        dBContext.PersonData.RemoveRange(dBContext.PersonData);
        dBContext.PersonData.Add(person);
        await dBContext.SaveChangesAsync();
    }

    public async Task UpdatePerson(Person person)
    {
        dBContext.PersonData.Update(person);
        await dBContext.SaveChangesAsync();
    }
}

