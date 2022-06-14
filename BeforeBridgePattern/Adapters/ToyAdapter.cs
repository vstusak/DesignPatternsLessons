using BeforeBridgePattern.Models;

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
