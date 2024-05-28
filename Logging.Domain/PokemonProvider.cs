using Logging.Domain;
using System.Text.Json;

namespace Logging.Api.Controllers;

public class PokemonProvider : IPokemonProvider
{
    private IEnumerable<Pokemon> GetAll()
    {
        var content = File.ReadAllText("pokemons.json");
        return JsonSerializer.Deserialize<IEnumerable<Pokemon>>(content);
    }

    public Pokemon Get()
    {
        var result = GetAll();
        return result.First();
    }
}