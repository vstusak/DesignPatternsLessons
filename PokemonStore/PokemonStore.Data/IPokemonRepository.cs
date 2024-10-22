using PokemonStore.Contracts;

namespace PokemonStore.Data;

public interface IPokemonRepository
{
    IEnumerable<Pokemon> GetAll();

    IEnumerable<Pokemon> GetByType(string pokemonType);

    Pokemon? GetById(int id);
    void Delete(int id);
}