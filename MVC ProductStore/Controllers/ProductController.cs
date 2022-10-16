using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_ProductStore.Models.Entities;
using MVC_ProductStore.Models.Repositories;
using MVC_ProductStore.Models.ViewModel;

namespace MVC_ProductStore.Controllers
{
    public class ProductController : Controller
    {
        public IProductRepository repository;

        public ProductController(IProductRepository repository)
        {
            this.repository = repository;
        }

        // GET: ProductController
        public IActionResult Index()
        {
            var products = repository.GetAll();
            return View(products);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            var product = repository.GetProductById(id);
            return View(product);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            var product = repository.GetProductEditViewModel();
            return View(product);
        }

        // POST: ProductController/Create
        [HttpPost]
        public ActionResult Create(
            [Bind("Name,Description,Price,ManufacturerId,CategoryId")] Product product)
        {
            //var newProduct = repository.GetProductEditViewModel();
            if (ModelState.IsValid)
            {
                var newProduct = new Product()
                {
                    CategoryId = product.CategoryId,
                    Description = product.Description,
                    ManufacturerId = product.ManufacturerId,
                    Name = product.Name,
                    Price = product.Price,
                };
                repository.Save(newProduct);
                //TempData["message"] = string.Format("{0} har blitt opprettet", product.Name);
                return RedirectToAction("Index");
            }
            return View();
        }
        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            var productToEdit = repository.GetProductEditViewModel();
            productToEdit.Name = repository.GetProductById(id).Name;
            productToEdit.Price = repository.GetProductById(id).Price;
            productToEdit.ManufacturerId = repository.GetProductById(id).ManufacturerId;
            productToEdit.CategoryId = repository.GetProductById(id).CategoryId;
            productToEdit.Description = repository.GetProductById(id).Description;
            return View(productToEdit);
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, [Bind("ProductId,Name,Description,Price,ManufacturerId,CategoryId")] ProductEditViewModel product)
        {
            if (ModelState.IsValid)
            {
                var editProduct = repository.GetProductById(id);
                editProduct.CategoryId = product.CategoryId;
                editProduct.Description = product.Description;
                editProduct.ManufacturerId = product.ManufacturerId;
                editProduct.Name = product.Name;
                editProduct.Price = product.Price;
                repository.Edit(editProduct);
                //TempData["message"] = string.Format("{0} har blitt endret", product.Name);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Product/Delete/5
        public IActionResult Delete(int id)
        {

            var product = repository.GetProductById(id);

            return View(product);
        }

        // POST: Products2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (repository.GetProductById(id) == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Product'  is null.");
            }

            var product = repository.GetProductById(id);
            if (product != null)
            {
                repository.Delete(product);
            }
            //TempData["message"] = string.Format("{0} har blitt slettet", product.Name);
            return RedirectToAction(nameof(Index));
        }
    }
}
