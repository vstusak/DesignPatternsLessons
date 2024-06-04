using Logging.Data;
using Logging.Data.enums;

namespace Logging.Domain
{
    public interface IPokemonProvider
    {
        IEnumerable<Pokemon> GetByPokemonType(string pokemonType);
        Pokemon GetById(int id);
    }
}