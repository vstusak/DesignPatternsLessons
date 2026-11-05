using ProductFuriousStore.Contracts.Entities;

namespace ProductFuriousStore.Logic.Repo;

// use ProductFuriousStore.Logic.ProductStoreContext
// run of AppHost is working even with the sql server running in docker - necessary to tun the API manually

// @TODO Try database migrations

public interface IProductRepo
{
    public Product? Get(int id);
    public Product Add(Product product);
    public void Delete(int id);
    public IEnumerable<Product> GetAll();
    public void Update(Product product);
}
