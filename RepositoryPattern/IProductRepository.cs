namespace _04_RepositoryPattern
{
    internal interface IProductRepository
    {
        IEnumerable<Product> GetAll();
    }
}