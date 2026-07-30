using ProductFuriousStore.Contracts.Entities;

namespace ProductFuriousStore.Logic.Repo;

// TODO new repo implementation connected to a real DB (aspire db in docker),0
// use ProductFuriousStore.Logic.ProductStoreContext

public interface IProductRepo
{
    public Product Get(int id);
    public Product Add(Product product);
    public void Delete(int id);
    public IEnumerable<Product> GetAll();
    public void Update(Product product);
}
