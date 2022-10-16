using MVC_ProductStore.Models.Entities;
using MVC_ProductStore.Models.ViewModel;

namespace MVC_ProductStore.Models.Repositories;

public interface IProductRepository
{
    IEnumerable<Product> GetAll();
    Product GetProductById(int? id);
    Boolean ProductExists(int id);
    void Save(Product product);
    void Edit(Product product);
    void Delete(Product product);
    ProductEditViewModel GetProductEditViewModel();
}