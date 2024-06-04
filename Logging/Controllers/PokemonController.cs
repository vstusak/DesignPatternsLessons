using Logging.Data;
using Logging.Data.enums;
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
        public IEnumerable<Pokemon> Get(string pokemonType = "All")
        {
            _logger.LogInformation($"Pokemon request called with {nameof(pokemonType)}: {pokemonType}");
            return _pokemonProvider.GetByPokemonType(pokemonType);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            _logger.LogDebug($"Pokemon request called with {nameof(id)}: {id}");
            var result = _pokemonProvider.GetById(id);
            if (result == null)
            {
                _logger.LogWarning($"Pokemon not found with id: {id}");
                return NotFound();
            }

            return Ok(result);

        }
    }
}
