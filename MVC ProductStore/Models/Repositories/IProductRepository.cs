using MVC_ProductStore.Models.Entities;

namespace MVC_ProductStore.Models.Repositories;

public interface IProductRepository
{
    IEnumerable<Product> GetAll();
    void Save(Product product);
}