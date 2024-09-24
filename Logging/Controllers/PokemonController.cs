using Microsoft.AspNetCore.Mvc;
using PokemonStore.Contracts;
using PokemonStore.Data;
using PokemonStore.Domain;

namespace PokemonStore.WebApi.Controllers;

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

    [ProducesResponseType(typeof(Pokemon), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("{id:int}")]
    public IActionResult Get(int id)
    {
        _logger.LogInformation($"Pokemon request called with {nameof(id)}: {id}");
        var result = _pokemonProvider.GetById(id);
        if (result == null)
        {
            _logger.LogWarning($"Pokemon not found with id: {id}");
            return NotFound();
        }

        return Ok(result);

    }
}