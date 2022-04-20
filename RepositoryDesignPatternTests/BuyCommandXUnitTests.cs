using System;
using Moq;
using RepositoryDesignPattern;
using RepositoryDesignPattern.Commands;
using RepositoryDesignPattern.Context;
using Xunit;

namespace RepositoryDesignPatternTests
{
    public class BuyCommandXUnitTests
    {
        public MockRepository mockRepository { get; set; } = new MockRepository(MockBehavior.Strict);

        [Fact]
        public void CanExecute_ProductQuantityMoreThan0_True()
        {
            //Arrange
            var product = new Product { Quantity = 1 };

        //  var repositoryMock = new Mock<IRepository<Product>>(MockBehavior.Strict);
            var repositoryMock = mockRepository.Create<IRepository<Product>>();

            repositoryMock.Setup(rm => rm.Get(product.ProductId)).Returns(product);


            var buyCommand = new BuyCommand(repositoryMock.Object, product.ProductId);

            //Act
            var actualResult = buyCommand.CanExecute();

            //Assert
            Assert.True(actualResult);
            mockRepository.VerifyAll();
        }

        [Fact]
        public void CanExecute_ProductQuantityEquals0_False()
        {
            //Arrange
            var product = new Product { Quantity = 0 };

            var repositoryMock = new Mock<IRepository<Product>>(MockBehavior.Strict);
            repositoryMock.Setup(rm => rm.Get(product.ProductId)).Returns(product);

            var buyCommand = new BuyCommand(repositoryMock.Object, product.ProductId);

            //Act
            var actualResult = buyCommand.CanExecute();

            //Assert
            Assert.False(actualResult);
        }

        [Fact]
        public void Execute_ProductQuantityDecreasedFrom2To1_True()
        {
            //Arrange
            var product = new Product { Quantity = 2 };

            var repositoryMock = new Mock<IRepository<Product>>(MockBehavior.Strict);
            repositoryMock.Setup(rm => rm.Get(It.IsAny<Guid>())).Returns(product);
            repositoryMock.Setup(rm => rm.Update(It.IsAny<Product>())).Returns(product);
            repositoryMock.Setup(rm => rm.SaveChanges());

            var buyCommand = new BuyCommand(repositoryMock.Object, product.ProductId);

            //Act
            buyCommand.Execute();

            //Assert
            Assert.Equal(1, product.Quantity);
        }

        [Fact]
        public void Execute_UpdateCalledOnce_True()
        {
            //Arrange
            var product = new Product { Quantity = 2 };

            var repositoryMock = new Mock<IRepository<Product>>(MockBehavior.Strict);
            repositoryMock.Setup(rm => rm.Get(It.IsAny<Guid>())).Returns(product);
            repositoryMock.Setup(rm => rm.Update(It.IsAny<Product>())).Returns(product);
            repositoryMock.Setup(rm => rm.SaveChanges());

            var buyCommand = new BuyCommand(repositoryMock.Object, product.ProductId);

            //Act
            buyCommand.Execute();

            //Assert
            repositoryMock.Verify(rm => rm.Update(It.IsAny<Product>()), Times.Once);
        }

        [Fact]
        public void Execute_SaveChangesCalledOnce_True()
        {
            //Arrange
            var product = new Product { Quantity = 2 };

            var repositoryMock = new Mock<IRepository<Product>>(MockBehavior.Strict);
            repositoryMock.Setup(rm => rm.Get(It.IsAny<Guid>())).Returns(product);
            repositoryMock.Setup(rm => rm.Update(It.IsAny<Product>())).Returns(product);
            repositoryMock.Setup(rm => rm.SaveChanges());

            var buyCommand = new BuyCommand(repositoryMock.Object, product.ProductId);

            //Act
            buyCommand.Execute();

            //Assert
            repositoryMock.Verify(rm => rm.SaveChanges(), Times.Once);
        }
    }
}