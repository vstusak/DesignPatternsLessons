using System.Linq.Expressions;

namespace _04_RepositoryPattern
{
    internal interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product Add(Product product);
        Product Update(Product product);
        Product Get(string name);
        void Remove(Product product);

        IEnumerable<Product> Find(Expression<Func<Product, bool>> expression);
    }
}