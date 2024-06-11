
namespace Logging.Data
{
    //TODO: decide to refactor to IRepository<T>  
    public interface IPokemonRepository
    {
        IEnumerable<Pokemon> GetAll();
    }
}