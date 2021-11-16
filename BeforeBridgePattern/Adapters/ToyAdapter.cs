using BeforeBridgePattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern.Adapters
{
    public class ToyAdapter : IProduct
    {
        private readonly Toy _toy;

        public ToyAdapter(Toy toy)
        {
            _toy = toy;
        }

        public string GetDescription()
        {
            return $"{_toy.Description}, {_toy.Color}, {_toy.Age}";
        }
    }
}
