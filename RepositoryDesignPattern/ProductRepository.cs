using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using RepositoryDesignPattern.Context;
using RepositoryDesignPattern.Memento;

namespace RepositoryDesignPattern
{
    public class ProductRepository : GenericRepository<Product>
    {
        public ProductRepository(WarehouseContext context) : base(context)
        {
        }

        public ProductRepositoryMemento CreateMemento()
        {
            var serializedAllProducts = JsonConvert.SerializeObject(Context.Products);
            return new ProductRepositoryMemento(serializedAllProducts);
        }

        public void SetMemento(ProductRepositoryMemento memento)
        {
            var serializedAllProducts = memento.GetState();
            var newContext = JsonConvert.DeserializeObject<List<Product>>(serializedAllProducts);
            Context.Products.RemoveRange(Context.Products);
            Context.SaveChanges();
            Context.Products.AddRange(newContext);
            Context.SaveChanges();
        }

        public override Product Update(Product product)
        {
            using var context2 = new WarehouseContext();
            var dbProduct = context2.Products.Single(x => x.ProductId == product.ProductId);
            if (dbProduct.Quantity != product.Quantity)
            {
                product.LastQuantityModified = DateTimeOffset.UtcNow;
            }
            return base.Update(product);
        }
    }
}
