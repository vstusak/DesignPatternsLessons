using Logging.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Logging.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly ILogger<PokemonController> _logger;
        private PokemonProvider _pokemonProvider;

        public PokemonController(ILogger<PokemonController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public Pokemon Get()
        {
            // @TODO vyzkouset - vytvorit registraci a inicializaci PokemonProvider
            return _pokemonProvider.Get();
        }
    }
}
