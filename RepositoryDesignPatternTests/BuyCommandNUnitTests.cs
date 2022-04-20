using System;
using Moq;
using RepositoryDesignPattern;
using RepositoryDesignPattern.Commands;
using RepositoryDesignPattern.Context;
using NUnit;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace RepositoryDesignPatternTests
{
    [TestFixture]
    public class BuyCommandNUnitTests:TestBase
    {
        private Mock<IRepository<Product>> _repositoryMock;

        [SetUp] 
        public void Setup()
        {
            _repositoryMock = MockRepository.Create<IRepository<Product>>();
        }

        [Test]
        public void CanExecute_ProductQuantityMoreThan0_True()
        {
            //Arrange
            var product = new Product { Quantity = 1 };

            _repositoryMock.Setup(rm => rm.Get(product.ProductId)).Returns(product);
            
            var buyCommand = new BuyCommand(_repositoryMock.Object, product.ProductId);

            //Act
            var actualResult = buyCommand.CanExecute();

            //Assert
            Assert.True(actualResult);
        }

        [Test]
        public void CanExecute_ProductQuantityEquals0_False()
        {
            //Arrange
            var product = new Product { Quantity = 0 };
            
            _repositoryMock.Setup(rm => rm.Get(product.ProductId)).Returns(product);

            var buyCommand = new BuyCommand(_repositoryMock.Object, product.ProductId);

            //Act
            var actualResult = buyCommand.CanExecute();

            //Assert
            Assert.False(actualResult);
        }

        [Test]
        public void Execute_ProductQuantityDecreasedFrom2To1_True()
        {
            //Arrange
            var product = new Product { Quantity = 2 };
            
            _repositoryMock.Setup(rm => rm.Get(It.IsAny<Guid>())).Returns(product);
            _repositoryMock.Setup(rm => rm.Update(It.IsAny<Product>())).Returns(product);
            _repositoryMock.Setup(rm => rm.SaveChanges());

            var buyCommand = new BuyCommand(_repositoryMock.Object, product.ProductId);

            //Act
            buyCommand.Execute();

            //Assert
            Assert.AreEqual(1, product.Quantity);
        }

        [Test]
        public void Execute_UpdateCalledOnce_True()
        {
            //Arrange
            var product = new Product { Quantity = 2 };
            
            _repositoryMock.Setup(rm => rm.Get(It.IsAny<Guid>())).Returns(product);
            _repositoryMock.Setup(rm => rm.Update(It.IsAny<Product>())).Returns(product);
            _repositoryMock.Setup(rm => rm.SaveChanges());

            var buyCommand = new BuyCommand(_repositoryMock.Object, product.ProductId);

            //Act
            buyCommand.Execute();

            //Assert
            _repositoryMock.Verify(rm => rm.Update(It.IsAny<Product>()), Times.Once);
        }

        [Test]
        public void Execute_SaveChangesCalledOnce_True()
        {
            //Arrange
            var product = new Product { Quantity = 2 };
            
            _repositoryMock.Setup(rm => rm.Get(It.IsAny<Guid>())).Returns(product);
            _repositoryMock.Setup(rm => rm.Update(It.IsAny<Product>())).Returns(product);
            _repositoryMock.Setup(rm => rm.SaveChanges());

            var buyCommand = new BuyCommand(_repositoryMock.Object, product.ProductId);

            //Act
            buyCommand.Execute();

            //Assert
            _repositoryMock.Verify(rm => rm.SaveChanges(), Times.Once);
        }
    }

    public class TestBase

    {
        public MockRepository MockRepository { get; set; } 

        [SetUp]
        public void SetUp()
        {
            MockRepository = new MockRepository(MockBehavior.Strict);
        }

        [TearDown]
        public void TearDown()
        {
            MockRepository.VerifyAll();
        }

    }
}