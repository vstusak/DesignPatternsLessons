using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace Logging.Data;

public class PokemonContext : DbContext
{
    public DbSet<Pokemon> Pokemons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Pokemons.db");
    }

    public void DefaultSeed()
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();

        var content = File.ReadAllText("pokemons.json");
        var data = JsonSerializer.Deserialize<IEnumerable<Pokemon>>(content);
        Pokemons.AddRange(data);
        SaveChanges();
    }
}