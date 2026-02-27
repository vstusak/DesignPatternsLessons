using ProductStore.Contracts.Model;

namespace ProductStore.Data;

public interface IProductRepository
{
    Product? Get(int productId);
    IEnumerable<Product> GetForCategory(string category);
    void Delete(int id);
    void AddOrUpdate(Product product);
}