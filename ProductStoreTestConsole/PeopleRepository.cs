using Microsoft.EntityFrameworkCore;

namespace ProductStoreTestConsole;

public class PeopleRepository(PersonDBContext context)
{
    public async Task<List<Person>> GetAllAsync()
    {
        return await context.People.ToListAsync();
    }

    public async Task<Person> GetByIdAsync(int id)
    {
        return await context.People.FirstAsync(person => person.Id == id);
    }

    public async Task<Person> InsertAsync(Person person)
    {
        var insertResult = await context.People.AddAsync(person);
        await context.SaveChangesAsync();
        return insertResult.Entity;
    }
}