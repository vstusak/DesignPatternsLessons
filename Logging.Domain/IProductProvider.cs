using Logging.Domain.Model;

namespace Logging.Domain
{
    public interface IProductProvider
    {
        IEnumerable<Product> GetProductsForCategory(string category);
    }
}