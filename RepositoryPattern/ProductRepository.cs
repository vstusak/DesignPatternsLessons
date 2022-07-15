using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RepositoryPattern.Context;
using RepositoryPattern.Memento;

namespace RepositoryPattern
{
    public class ProductRepository : GenericRepository<Product>
    {
        public ProductRepository(WarehouseContext context)
            : base(context)
        {
        }

        public ProductRepositoryMemento CreateMemento()
        {
            var serializeObject = JsonConvert.SerializeObject(context.Products);
            return new ProductRepositoryMemento()
            {
                Content = serializeObject
            };
        }

        public override Product Update(Product entity)
        {
            var product = context.Products.Single(product => product.ProductId == entity.ProductId);

            if (product.Quantity != entity.Quantity)
            {
                product.Quantity = entity.Quantity;
                product.LastQuantityModified = DateTimeOffset.Now;
            }

            return base.Update(product);
        }

        public void SetMemento(ProductRepositoryMemento memento)
        {
            var products = JsonConvert.DeserializeObject<List<Product>>(memento.Content);
            context.Products = products;
        }
    }
}