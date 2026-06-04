using Microsoft.EntityFrameworkCore;
using Testcontainers.MsSql;

namespace ProductStoreTestConsole
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Starting SQL container!");

            await using var sqlContainer = new MsSqlBuilder("mcr.microsoft.com/mssql/server:2022-CU14-ubuntu-22.04")
                .Build();

            await sqlContainer.StartAsync();

            Console.WriteLine($"SQL Container started! Connection string: {sqlContainer.GetConnectionString()}");

            var connectionString = sqlContainer.GetConnectionString();
            var context = await CreateContextAsync(connectionString);
            await InsertData(context);
            ReadData(context);
        }

        private static void ReadData(PersonDBContext context)
        {
            foreach (var p in context.People)
            {
                Console.WriteLine($"{p.Id}: {p.Name} - {p.Age} yo");
            }
        }

        private async static Task InsertData(PersonDBContext context)
        {
            await context.People.AddAsync(new Person { Age = 18, Name = "Tomik Fulajtar" });
            await context.People.AddAsync(new Person { Age = 19, Name = "Milanek Karasek" });
            await context.SaveChangesAsync();
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
}
