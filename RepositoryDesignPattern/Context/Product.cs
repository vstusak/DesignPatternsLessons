using System;

namespace RepositoryDesignPattern.Context
{
    public class Product
    {
        public Guid ProductId { get; private set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public DateTimeOffset LastQuantityModified { get; set; }

        public Product()
        {
            ProductId = Guid.NewGuid();
        }

        public override string ToString()
        {
            return $"Name:{Name}, Price:{Price}, Quantity:{Quantity}";
        }
    }
}