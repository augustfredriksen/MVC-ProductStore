using Microsoft.AspNetCore.Mvc;
using MVC_ProductStore.Controllers;
using System.Collections;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using MVC_ProductStore.Models;
using MVC_ProductStore.Models.Entities;
using MVC_ProductStore.Models.Repositories;
using Xunit;
using Moq;
using MVC_ProductStore.Models.ViewModel;
using Xunit.Sdk;

namespace ProductXUnitTest
{
    public class UnitTest1
    {

        [Fact]
        public void ProductEditViewModelWorks()
        {
            //Arrange
            var mockUser = new Mock<UserManager<IdentityUser>>(Mock.Of<IUserStore<IdentityUser>>(), null, null, null, null, null, null, null, null);
            var productRepository = MockRepository.GetProductRepository();
            var productController = new ProductController(productRepository.Object);

            //Act
            var result = productController.Create();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsAssignableFrom<ProductEditViewModel>
                (viewResult.ViewData.Model);
        }
        [Fact]
        public void IndexReturnsView()
        {
            // Arrange
            var mockRepository = MockRepository.GetProductRepository();
            var controller = new ProductController(mockRepository.Object);

            // Act 
            var result = controller.Index();

            // Assert 
            var viewResult = Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void CreateReturnsView()
        {
            // Arrange
            var mockRepository = MockRepository.GetProductRepository();
            var controller = new ProductController(mockRepository.Object);

            // Act 
            var result = controller.Create();

            // Assert 
            var viewResult = Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void EditReturnsView()
        {
            // Arrange
            var mockRepository = MockRepository.GetProductRepository();
            var controller = new ProductController(mockRepository.Object);

            // Act 
            var result = controller.Edit(1);

            // Assert 
            var viewResult = Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void DetailsReturnsView()
        {
            // Arrange
            var mockRepository = MockRepository.GetProductRepository();
            var controller = new ProductController(mockRepository.Object);

            // Act 
            var result = controller.Details(It.IsAny<int>());

            // Assert 
            var viewResult = Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void DeleteReturnsView()
        {
            // Arrange
            var mockRepository = MockRepository.GetProductRepository();
            var controller = new ProductController(mockRepository.Object);

            // Act 
            var result = controller.Delete(It.IsAny<int>());

            // Assert 
            Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public void DeleteReturnsRedirectToAction()
        {
            // Arrange
            var mockRepository = MockRepository.GetProductRepository();
            var controller = new ProductController(mockRepository.Object);

            // Act 
            var result = controller.DeleteConfirmed(It.IsAny<int>());
            var modelState = controller.ModelState;

            // Assert 
            Assert.IsType<RedirectToActionResult>(result);
            Assert.True(modelState.IsValid);
            Assert.Empty(modelState.Keys);
        }
        [Fact]
        public void EditReturnsRedirectToAction()
        {
            // Arrange
            var mockRepository = MockRepository.GetProductRepository();
            var controller = new ProductController(mockRepository.Object);


            // Act 
            var result = controller.Edit(It.IsAny<int>(), It.IsAny<ProductEditViewModel>());
            var modelState = controller.ModelState;

            // Assert 
            Assert.IsType<RedirectToActionResult>(result);
            Assert.True(modelState.IsValid);
            Assert.Empty(modelState.Keys);
        }
        [Fact]
        public void CreateReturnsRedirectToAction()
        {
            // Arrange
            var mockRepository = MockRepository.GetProductRepository();
            var controller = new ProductController(mockRepository.Object);

            // Act 
            var result = controller.Create(It.IsAny<Product>());
            var modelState = controller.ModelState;

            // Assert 
            Assert.IsType<RedirectToActionResult>(result);
            Assert.True(modelState.IsValid);
            Assert.Empty(modelState.Keys);
        }
    }
}