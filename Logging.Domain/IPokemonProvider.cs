using Logging.Domain;

namespace Logging.Api.Controllers
{
    public interface IPokemonProvider
    {
        Pokemon Get();
    }
}