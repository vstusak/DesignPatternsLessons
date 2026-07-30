using ProductFuriousStore.Contracts.Entities;

namespace ProductFuriousStore.ApiService.Data
{

    public class ProductRepo: IProductRepo
    {
        public Product Get(int id)
        {
            var product = Products.Collection.FirstOrDefault(product => product.Id == id);

            if (product is null)
            {
                throw new ArgumentException($"Product with id {id} not found.");
            }

            return product;
        }

        public Product Add(Product product)
        {
            var newId = Products.Collection.Any() ? Products.Collection.Max(p => p.Id) + 1 : 1;
            var newProduct = product with { Id = newId };
            Products.Collection.Add(newProduct);
            return newProduct;
        }

        public void Delete(int id)
        {
            var product = Products.Collection.FirstOrDefault(product => product.Id == id);

            if (product is null)
            {
                throw new ArgumentException($"Product with id {id} not found.");
            }

            Products.Collection.Remove(product);
        }

        public IEnumerable<Product> GetAll()
        {
            return Products.Collection;
        }

        public void Update(Product product)
        {
            var existingProduct = Products.Collection.FirstOrDefault(p => p.Id == product.Id);

            if (existingProduct is null)
            {
                throw new ArgumentException($"Product with id {product.Id} not found.");
            }

            Products.Collection.Remove(existingProduct);
            Products.Collection.Add(product);
        }

        //TODO: use everywhere the repo instead of the static Products.Collection
    }
}
