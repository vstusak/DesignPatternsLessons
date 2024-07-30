using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;

namespace Logging.Data;

public class PokemonContext : DbContext
{
    public DbSet<Pokemon> Pokemons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Pokemons.db");
        //optionsBuilder.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddDebug()));
    }

    public void DefaultSeed()
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();

        var content = File.ReadAllText("pokemons.json");
        var data = JsonSerializer.Deserialize<IEnumerable<Pokemon>>(content);
        Pokemons.AddRange(data.DistinctBy(p => p.Id));
        SaveChanges();
    }

    public bool DatabaseExists()
    {
        return Database.CanConnect() && Database.GetService<IRelationalDatabaseCreator>().HasTables();
    }
}