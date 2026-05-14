using Microsoft.EntityFrameworkCore;
using Testcontainers.MsSql;

namespace ProductStoreTestConsole
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Starting SQL container!");

            await using var sqlContainer = new MsSqlBuilder()
                .Build();

            await sqlContainer.StartAsync();

            Console.WriteLine($"SQL Container started! Connection string: {sqlContainer.GetConnectionString()}");

            var connectionString = sqlContainer.GetConnectionString();
            var context = await CreateContextAsync(connectionString);
        }

        private static async Task<PersonDBContext> CreateContextAsync(string connectionString)
        {
            var options = new DbContextOptionsBuilder<PersonDBContext>()
                .UseSqlServer(connectionString)
                .Options;

            var context = new PersonDBContext(options);

            await context.Database.EnsureCreatedAsync();
            Console.WriteLine("Database created!");
            return context;
        }
    }

    public class PersonDBContext : DbContext
    {
        public PersonDBContext(DbContextOptions<PersonDBContext> options) : base(options)
        {
        }
        public DbSet<Person> People { get; set; } = null!;
    }

    public class Person
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int Age { get; set; }
    }
}
