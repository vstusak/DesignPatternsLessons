using ProductFuriousStore.Contracts.Entities;

namespace ProductFuriousStore.ApiService.Data
{
    public interface IProductRepo
    {
        public Product Get(int id);
        public Product Add(Product product); 
        public void Delete(int id);
        public IEnumerable<Product> GetAll();
        public void Update(Product product);
    }
}
