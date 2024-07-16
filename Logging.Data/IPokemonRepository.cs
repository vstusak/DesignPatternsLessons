namespace Logging.Data;

public interface IPokemonRepository
{
    IEnumerable<Pokemon> GetAll();

    IEnumerable<Pokemon> GetByType(string pokemonType);

    Pokemon? GetById(int id);
}