﻿using Logging.Data.Model;

namespace Logging.Data;

public interface IProductRepository
{
    Product? Get(int productId);
    IEnumerable<Product> GetForCategory(string category);
}