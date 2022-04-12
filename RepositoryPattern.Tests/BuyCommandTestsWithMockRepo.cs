using System;
using RepositoryPattern.Commands;
using Moq;
using RepositoryPattern.Context;
using NUnit.Framework;

namespace RepositoryPattern.Tests
{
    public class BuyCommandTestsWithMockRepo : TestsBase
    {
        private Mock<IRepository<Product>> _productRepositoryMock;

        [SetUp]
        public void Setup()
        {
            _productRepositoryMock = MockRepo.Create<IRepository<Product>>();
        }

        [Test]
        public void ProductWithQuantityOne_Execute_QuantityDecreasedByOne()
        {
            //Arrange
            var product = GetProduct();
            _productRepositoryMock
                .Setup(prm => prm.Get(It.IsAny<Guid>()))
                .Returns(product);
            _productRepositoryMock
                .Setup(prm => prm.Update(It.IsAny<Product>()))
                .Returns(product);

            var unitUnderTest = new BuyCommand(product, _productRepositoryMock.Object);

            //Act
            unitUnderTest.Execute();

            //Assert
            Assert.AreEqual(0, product.Quantity);
        }

        [Test]
        public void ProductWithQuantityTen_Execute_UpdatedProductRepository()
        {
            //Arrange
            var product = GetProduct();
            _productRepositoryMock
                .Setup(prm => prm.Get(It.IsAny<Guid>()))
                .Returns(product);
            _productRepositoryMock
                .Setup(prm => prm.Update(It.IsAny<Product>()))
                .Returns(product);

            var unitUnderTest = new BuyCommand(product, _productRepositoryMock.Object);

            //Act
            unitUnderTest.Execute();

            //Assert
            _productRepositoryMock.Verify(prm => prm.Update(It.IsAny<Product>()), Times.Once);
        }

        private static Product GetProduct()
        {
            return new Product()
            {
                LastQuantityModified = DateTimeOffset.UtcNow,
                Name = "Testing product",
                Price = 100,
                Quantity = 1
            };
        }
    }
}