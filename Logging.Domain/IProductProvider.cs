using Logging.Data.Api.Model;

namespace ProductStore.Domain
{
    public interface IProductProvider
    {
        IEnumerable<Product> GetProductsForCategory(string category);
        Product? GetProduct(int productId);
        void DeleteProduct(int id);
    }
}