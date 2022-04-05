using System;
using Xunit;
using RepositoryPattern.Commands;
using Moq;
using RepositoryPattern.Context;

namespace RepositoryPattern.Tests
{
    public class BuyCommandTests
    {
        [Fact]
        public void ProductWithQuantityOne_Execute_QuantityDecreasedByOne()
        {
            //Arrange
            var productRepositoryMock = new Mock<IRepository<Product>>(MockBehavior.Strict);
            var product = new Product()
            {
                LastQuantityModified = DateTimeOffset.UtcNow,
                Name = "Testing product",
                Price = 100,
                Quantity = 1
            };

            productRepositoryMock.Setup(prm => prm.Get(It.IsAny<Guid>()))
                .Returns(product);
            productRepositoryMock
                .Setup(prm => prm.Update(It.IsAny<Product>()))
                .Returns(product);

            var unitUnderTest = new BuyCommand(product, productRepositoryMock.Object);

            //Act
            unitUnderTest.Execute();

            //Assert
            Assert.Equal(0, product.Quantity);
        }

        [Fact]
        public void ProductWithQuantityTen_Execute_UpdatedProductRepository()
        {
            //Arrange
            var productRepositoryMock = new Mock<IRepository<Product>>(MockBehavior.Strict);
            var product = new Product()
            {
                LastQuantityModified = DateTimeOffset.UtcNow,
                Name = "Testing product",
                Price = 100,
                Quantity = 10
            };

            productRepositoryMock
                .Setup(prm => prm.Get(It.IsAny<Guid>()))
                .Returns(product);
            productRepositoryMock
                .Setup(prm => prm.Update(It.IsAny<Product>()))
                .Returns(product);

            var unitUnderTest = new BuyCommand(product, productRepositoryMock.Object);

            //Act
            unitUnderTest.Execute();

            //Assert
            productRepositoryMock.Verify(prm => prm.Update(It.IsAny<Product>()), Times.Once);
        }
    }
}