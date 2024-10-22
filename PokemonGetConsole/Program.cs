using PokemonStore.Contracts;
using System.Net.Http.Json;

var client = new HttpClient();
client.BaseAddress = new Uri("https://localhost:7246/");
var response = await client.GetAsync("Pokemon");
var pokemons = await response.Content.ReadFromJsonAsync<List<Pokemon>>() ?? new();

Console.WriteLine(String.Join(", ", pokemons.Select(p => p.Name)));