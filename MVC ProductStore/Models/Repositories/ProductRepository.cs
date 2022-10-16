using Microsoft.EntityFrameworkCore;
using MVC_ProductStore.Data;
using MVC_ProductStore.Models.Entities;
using MVC_ProductStore.Models.ViewModel;

namespace MVC_ProductStore.Models.Repositories;

public class ProductRepository : IProductRepository
{
    private ApplicationDbContext db;
    public ProductRepository(ApplicationDbContext db)
    {
        this.db = db;
    }

    public void Delete(Product product)
    {
        db.Product.Remove(product);
        db.SaveChanges();
    }

    public void Edit(Product product)
    {
        db.Product.Update(product);
        db.SaveChanges();
    }

    public IEnumerable<Product> GetAll()
    {
        var products = db.Product
            .Include(cat => cat.Category)
            .Include(man => man.Manufacturer)
            .ToList();
        return products;
    }

    public Product GetProductById(int? id)
    {
        var product = db.Product
            .Include(cat => cat.Category)
            .Include(man => man.Manufacturer)
            .FirstOrDefault(i => i.ProductId == id);
        return product;
    }

    public ProductEditViewModel GetProductEditViewModel()
    {
        var p = (from o in db.Product.Include("Category").Include("Manufacturer")
            select new ProductEditViewModel()).FirstOrDefault();
        p.Categories = db.Category.ToList();
        p.Manufacturers = db.Manufacturer.ToList();
        return p;
    }


    public bool ProductExists(int id)
    {
        return db.Product.Any(e => e.ProductId == id);
    }

    public void Save(Product product)
    {
        db.Product.Add(product);
        db.SaveChanges();
    }
}