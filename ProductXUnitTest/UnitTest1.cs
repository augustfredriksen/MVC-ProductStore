using Microsoft.AspNetCore.Mvc;
using MVC_ProductStore.Controllers;
using System.Collections;
using MVC_ProductStore.Models;
using MVC_ProductStore.Models.Entities;
using MVC_ProductStore.Models.Repositories;
using Xunit;
using Moq;
using Xunit.Sdk;

namespace ProductXUnitTest
{
    public class UnitTest1
    {
        private Mock<IProductRepository> _repository;
        [Fact]
        public void IndexReturnsAllProducts()
        {
            // Arrange
            _repository = new Mock<IProductRepository>();

            List<Product> fakeProducts = new List<Product>{
                new Product {Name="Hammer", Price=121.50m, Category="Verktøy"},
                new Product {Name="Vinkelsliper", Price=1520.00m, Category ="Verktøy"},
                new Product {Name="Melk", Price=14.50m, Category ="Dagligvarer"},
                new Product {Name="Kjøttkaker", Price=32.00m, Category ="Dagligvarer"},
                new Product {Name="Brød", Price=25.50m, Category ="Dagligvarer"}
            };
            _repository.Setup(m => m.GetAll()).Returns(fakeProducts);
            var controller = new ProductController(_repository.Object);

            // Act 
            var result = (ViewResult)controller.Index();

            // Assert 
            Assert.Equal(fakeProducts, result.ViewData.Model);
            Assert.NotNull(result);
            var products = result.ViewData.Model as List<Product>;
            Assert.Equal(5, products?.Count);
        }

        [Fact]
        public void SaveIsCalledWhenProdcutIsCreated()
        {
            {
                // Arrange 
                _repository = new Mock<IProductRepository>();
                _repository.Setup(x => x.Save(It.IsAny<Product>()));
                var controller = new ProductController(_repository.Object);

                // Act 
                var result = controller.Create(new Product());

                // Assert 
                _repository.VerifyAll();
                // test på at save er kalt et bestemt antall ganger 
                //_repository.Verify(x => x.save(It.IsAny<Product>()), Times.Exactly(1)); 

            }
        }
    }
}