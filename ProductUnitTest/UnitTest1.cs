using System.Collections;
using Microsoft.AspNetCore.Mvc;
using MVC_ProductStore.Controllers;
using MVC_ProductStore.Models;
using MVC_ProductStore.Models.Entities;
using MVC_ProductStore.Models.Repositories;

namespace ProductUnitTest
{
    [TestClass]
    public class ProductControllerTest
    {
        IProductRepository _repository;
        [TestMethod]
        public void IndexReturnsNotNullResult()
        {
            // Arrange 

            var controller = new ProductController(_repository);

            // Act 
            var result = controller.Index() as ViewResult;

            // Assert 

            Assert.IsNotNull(result, "View Result is null");

        }

        [TestMethod]
        public void IndexReturnsAllProducts()
        {
            // Arrange
            var controller = new ProductController(_repository);
            // 1 - Opprette et sett med produkter
            _repository = new ProductRepository();
            // 2 - Opprette et fake repository
            // 3 - Opprette kontroller med fake repository

            // Act
            // 1 - Kalle index metoden på kontrolleren
            var result = controller.Index() as ViewResult;

            // Assert
            // 1 - Benytt Assert klassen for å finne ut at rett type objekter er returnert
            CollectionAssert.AllItemsAreInstancesOfType((ICollection)result.ViewData.Model, typeof(Product));
            Assert.IsNotNull(result, "View result is null");
            // 2 - At antall produkter er korrekt
            var products = result.ViewData.Model as List<Product>;
            Assert.AreEqual(5, products.Count, "Got wrong number of products");

        }
    }
}