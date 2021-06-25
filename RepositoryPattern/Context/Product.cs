using System;

namespace RepositoryPattern.Context
{
    public class Product
    {
        public Product()
        {
            ProductId = Guid.NewGuid();
        }

        public Guid ProductId { get; private set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public DateTimeOffset LastQuantityModified { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, Price: {Price}, Quantity: {Quantity}";
        }
    }
}