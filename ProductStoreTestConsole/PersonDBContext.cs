using Microsoft.EntityFrameworkCore;

namespace ProductStoreTestConsole;

public class PersonDBContext : DbContext
{
    public PersonDBContext(DbContextOptions<PersonDBContext> options) : base(options)
    {
    }
    public DbSet<Person> People { get; set; } = null!;
}