using Microsoft.EntityFrameworkCore;
using ProductFuriousStore.Contracts.Entities;

namespace ProductFuriousStore.Logic.Repo;

// @TODO Apply async
public class ProductDatabaseRepo : IProductRepo
{
    private readonly ProductStoreContext _context;

    public ProductDatabaseRepo(ProductStoreContext context)
    {
        _context = context;
    }

    public Product? Get(int id)
    {
        return _context.Products.Find(id);
    }

    public Product Add(Product product)
    {
        var entity = _context.Products.Add(product).Entity;
        _context.SaveChanges();
        return entity;
    }

    public void Delete(int id)
    {
        var count = _context.Products.Where(product => product.Id == id).ExecuteDelete();
    }

    public IEnumerable<Product> GetAll()
    {
        return _context.Products.ToList();
    }

    public void Update(Product product)
    {
        _context.Products.Update(product);
        _context.SaveChanges();
    }
}