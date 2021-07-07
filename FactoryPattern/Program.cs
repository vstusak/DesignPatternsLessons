using System;

namespace FactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var shippingProviderFactory = new ShippingProviderFactory();
            ShoppingCart cart = new ShoppingCart(shippingProviderFactory);
            Console.WriteLine(cart.FinalizeOrder("SK", ""));
        }
    }
}
