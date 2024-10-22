using PokemonStore.Contracts;
using PokemonStore.Data;

namespace PokemonStore.Domain;

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
        return _pokemonRepository.GetByType(pokemonType);
    }

    public Pokemon GetById(int id)
    {
        return _pokemonRepository.GetById(id);
    }

    public void Delete(int id)
    {
        _pokemonRepository.Delete(id);
    }
}