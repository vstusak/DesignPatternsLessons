using Logging.Data.Api.Model;

namespace Logging.Data;

public interface IProductRepository
{
    Product? Get(int productId);
    IEnumerable<Product> GetForCategory(string category);
    void Delete(int id);
    void AddOrUpdate(Product product);
}