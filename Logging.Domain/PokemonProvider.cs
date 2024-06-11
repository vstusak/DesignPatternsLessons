using Logging.Data;
using Logging.Data.enums;
using System.Text.Json;

namespace Logging.Domain;

public class PokemonProvider : IPokemonProvider
{
    private readonly IPokemonRepository _pokemonRepository;

    public PokemonProvider(IPokemonRepository pokemonRepository)
    {
        _pokemonRepository = pokemonRepository;
    }
    //private IEnumerable<Pokemon> GetAll()
    //{
    //    var content = File.ReadAllText("pokemons.json");
    //    return JsonSerializer.Deserialize<IEnumerable<Pokemon>>(content);
    //}

    public IEnumerable<Pokemon> GetByPokemonType(string pokemonType)
    {
        return _pokemonRepository.GetAll().Where(pokemon => pokemon.Type1 == pokemonType || pokemonType == "All");
    }

    public Pokemon GetById(int id)
    {
        return _pokemonRepository.GetAll().SingleOrDefault(pokemon => pokemon.Id == id);
    }
}