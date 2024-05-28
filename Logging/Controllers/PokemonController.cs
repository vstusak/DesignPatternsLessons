using Logging.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Logging.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly ILogger<PokemonController> _logger;
        private readonly IPokemonProvider _pokemonProvider;

        public PokemonController(ILogger<PokemonController> logger, IPokemonProvider pokemonProvider)
        {
            _logger = logger;
            _pokemonProvider = pokemonProvider;
        }

        [HttpGet]
        public Pokemon Get()
        {
            _logger.LogInformation("Pokemon request called");
            return _pokemonProvider.Get();
        }
    }
}
