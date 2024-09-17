using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace PokemonStore.Data;

public class PokemonRepository : IPokemonRepository
{
    private readonly PokemonContext _pokemonContext;
    private readonly ILogger<PokemonRepository> _logger;
    private readonly ILogger _dalLogger;

    public PokemonRepository(PokemonContext pokemonContext, ILogger<PokemonRepository> logger, ILoggerFactory loggerFactory)
    {
        _pokemonContext = pokemonContext;
        _logger = logger;
        _dalLogger = loggerFactory.CreateLogger("DataAccessLayer");
    }

    public IEnumerable<Pokemon> GetAll()
    {
        _logger.LogWarning("Retrieving all pokemons");
        return _pokemonContext.Pokemons;
    }

    public IEnumerable<Pokemon> GetByType(string pokemonType)
    {
        _logger.LogInformation("Retrieving pokemons with type {PokemonType}", pokemonType);

        if (pokemonType.Equals("all", StringComparison.InvariantCultureIgnoreCase))
        {
            _logger.LogWarning("Retrieving all pokemons");
        }

        var stopwatch = Stopwatch.StartNew();
        var result = _pokemonContext.Pokemons.Where(pokemon => pokemon.Type1 == pokemonType || pokemonType == "All");
        stopwatch.Stop();

        var query = result.ToQueryString();
        _dalLogger.LogInformation("Executed query {Query}", query);
        _dalLogger.LogInformation("DAL querying pokemons finished in {Ticks} ticks", stopwatch.ElapsedTicks);

        return result;
    }

    public Pokemon? GetById(int id)
    {
        _logger.LogInformation("Retrieving pokemon with ID {PokemonId}", id);
        return _pokemonContext.Pokemons.Find(id);
    }
}