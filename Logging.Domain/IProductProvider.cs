using Logging.Data.Api.Model;

namespace Logging.Domain
{
    public interface IProductProvider
    {
        IEnumerable<Product> GetProductsForCategory(string category);
        Product? GetProduct(int productId);
    }
}