﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RepositoryDesignPattern.Context;

namespace RepositoryDesignPattern
{
    public class WarehouseService
    {
        private readonly IRepository<Product> _productRepository;

        public WarehouseService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }
        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public IEnumerable<Product> GetLuxuryProducts()
        {
            var context = new WarehouseContext();

            return context.Products.Where(p => p.Price > 10);
        }

        public Product BuyProduct(Product product)
        {
            product.Quantity -= 1;
            return _productRepository.Update(product);
        }
    }
}