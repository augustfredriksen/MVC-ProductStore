using Moq;
using MVC_ProductStore.Models.Entities;
using MVC_ProductStore.Models.Repositories;
using MVC_ProductStore.Models.ViewModel;

namespace ProductXUnitTest;

internal class MockRepository
{
    public static Mock<IProductRepository> GetProductRepository()
    {
        List<Product> fakeProducts = new List<Product>{
            new Product {
                ProductId = 1,
                Name = "Hammer",
                Price = 121.50m,
                CategoryId = 1,
                ManufacturerId = 1

            },
            new Product {
                ProductId = 2,
                Name = "Vinkelsliper",
                Price = 1520.00m,
                CategoryId = 1,
                ManufacturerId = 1

            },
            new Product {
                ProductId = 3,
                Name = "Melk",
                Price = 43.00m,
                CategoryId = 3,
                ManufacturerId = 2

            },
            new Product {
                ProductId = 4,
                Name = "Kjøttkaker",
                Price = 17.00m,
                CategoryId = 3,
                ManufacturerId = 2

            },
            new Product
            {
                Name="Brød",
                Price=25.50m,
                CategoryId = 3,
                ManufacturerId = 1
            }
        };

        var mockProductRepository = new Mock<IProductRepository>();
        mockProductRepository.Setup(repo => repo.GetAll()).Returns(fakeProducts);
        mockProductRepository.Setup(repo => repo.Delete(It.IsAny<Product>()));
        mockProductRepository.Setup(repo => repo.Edit(It.IsAny<Product>()));
        mockProductRepository.Setup(repo => repo.Save(It.IsAny<Product>()));
        mockProductRepository.Setup(repo => repo.GetProductEditViewModel()).Returns(new ProductEditViewModel());
        mockProductRepository.Setup(repo => repo.GetProductById(It.IsAny<int>())).Returns(fakeProducts[0]);
        return mockProductRepository;
    } 
}