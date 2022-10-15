using MVC_ProductStore.Data;
using MVC_ProductStore.Models.Entities;

namespace MVC_ProductStore.Models.Repositories;

public class ProductRepository : IProductRepository
{
    private ApplicationDbContext db;
    public ProductRepository(ApplicationDbContext db)
    {
        this.db = db;
    }

    public IEnumerable<Product> GetAll()
    {
        var products = db.Product;
        return products;
    }

    public void Save(Product product)
    {
        db.Add(product);
    }
}