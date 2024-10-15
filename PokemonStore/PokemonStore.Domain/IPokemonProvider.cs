using PokemonStore.Contracts;
using PokemonStore.Data.enums;
using PokemonStore.Data;

namespace PokemonStore.Domain
{
    public interface IPokemonProvider
    {
        IEnumerable<Pokemon> GetByPokemonType(string pokemonType);
        Pokemon GetById(int id);
        void Delete(int id);
    }
}