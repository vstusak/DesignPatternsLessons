using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging.Data
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly PokemonContext _pokemonContext;

        public PokemonRepository(PokemonContext pokemonContext)
        {
            _pokemonContext = pokemonContext;
        }

    }
}
