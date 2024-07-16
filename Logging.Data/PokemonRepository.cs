namespace Logging.Data;

public class PokemonRepository : IPokemonRepository
{
    private readonly PokemonContext _pokemonContext;

    public PokemonRepository(PokemonContext pokemonContext)
    {
        _pokemonContext = pokemonContext;
    }

    public IEnumerable<Pokemon> GetAll()
    {
        return _pokemonContext.Pokemons;
    }

    public IEnumerable<Pokemon> GetByType(string pokemonType)
    {
        return _pokemonContext.Pokemons.Where(pokemon => pokemon.Type1 == pokemonType || pokemonType == "All");
    }

    public Pokemon? GetById(int id)
    {
        return _pokemonContext.Pokemons.Find(id);
    }
}