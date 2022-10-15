using Microsoft.AspNetCore.Mvc;
using MVC_ProductStore.Models.Entities;
using MVC_ProductStore.Models.Repositories;

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

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            try
            {
                repository.Save(product);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
