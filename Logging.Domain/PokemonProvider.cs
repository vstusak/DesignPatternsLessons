using System.Text.Json;
using System.Text.Json.Nodes;
using Logging.Domain;

namespace Logging.Api.Controllers;

public class PokemonProvider
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