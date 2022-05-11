using Cqrs;
using Moq;
using NUnit.Framework;
using RepositoryDesignPattern;
using System;
using RepositoryDesignPattern.Context;
using RepositoryDesignPatternTests;

namespace CqrsTests.CommandHandlers
{
    [TestFixture]
    public class BuyCommandHandlerTests : TestBase
    {
        private Mock<IRepository<Product>> ProductRepositoryMock;
        private Mock<IProductQueryHandler> ProductQueryHandlerMock;

        [SetUp]
        public void SetUp()
        {
            ProductRepositoryMock = MockRepository.Create<IRepository<Product>>();
            ProductQueryHandlerMock = MockRepository.Create<IProductQueryHandler>();
        }

        private BuyCommandHandler CreateBuyCommandHandler()
        {
            return new BuyCommandHandler(
                ProductRepositoryMock.Object,
                ProductQueryHandlerMock.Object);
        }

        [Test]
        public void Execute_DefinedQuantity_QuantityDecreasedByOne()
        {
            // Arrange
            var originalProduct = new Product() { Name = "Prod1", Quantity = 10 };
            var buyCommandHandler = CreateBuyCommandHandler();
            BuyCommand command = new BuyCommand(Guid.NewGuid());
            ProductQueryHandlerMock.Setup(pqh => pqh.Execute(It.IsAny<ProductQuery>())).Returns(originalProduct);
            ProductRepositoryMock.Setup(pr => pr.Update(It.IsAny<Product>())).Returns(new Product());
            ProductRepositoryMock.Setup(pr => pr.SaveChanges());
            
            // Act
            buyCommandHandler.Execute(
                command);

            // Assert
            Assert.AreEqual(9, originalProduct.Quantity);
        }
    }
}
