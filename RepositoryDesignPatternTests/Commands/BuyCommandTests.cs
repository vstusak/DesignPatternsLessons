using System;
using Moq;
using NUnit.Framework;
using RepositoryDesignPattern;
using RepositoryDesignPattern.Commands;
using RepositoryDesignPattern.Context;

namespace RepositoryDesignPatternTests.Commands
{
    [TestFixture]
    public class BuyCommandTests : TestBase
    {
        private Mock<IRepository<Product>> RepositoryMock;

        [SetUp]
        public void SetUp()
        {
            RepositoryMock = MockRepository.Create<IRepository<Product>>();
        }

        private BuyCommand CreateBuyCommand()
        {
            return new BuyCommand(
                RepositoryMock.Object,
                Guid.NewGuid());
        }

        [TestCase(1,true)]
        [TestCase(0,false)]
        [TestCase(2,true)]
        public void CanExecute_QuantityOneOrMore_ReturnsTrue(int quantity,bool expectedResult)
        {
            // Arrange
            var buyCommand = this.CreateBuyCommand();

            var product = new Product
            {
                Quantity = quantity
            };
            RepositoryMock.Setup(rm => rm.Get(It.IsAny<Guid>())).Returns(product);

            // Act
            var result = buyCommand.CanExecute();

            // Assert
            Assert.AreEqual(expectedResult,result);
        }

        [TestCase(10, 9)]
        [TestCase(1, 0)]
        public void Execute_Quantity_QuantityDecreasedByOne(int quantity, int expectedResult)
        {
            // Arrange
            var buyCommand = this.CreateBuyCommand();

            var product = new Product
            {
                Quantity = quantity
            };

            RepositoryMock.Setup(rm => rm.Get(It.IsAny<Guid>())).Returns(product);
            RepositoryMock.Setup(rm => rm.Update(It.IsAny<Product>())).Returns(product);
            RepositoryMock.Setup(rm => rm.SaveChanges());

            // Act
            buyCommand.Execute();

            // Assert
            Assert.AreEqual(expectedResult, product.Quantity);
        }

        [TestCase(1,2 )]
        [TestCase(99, 100)]
        public void Undo_Quantity_QuantityIncreasedByOne(int quantity,int expectedResult)
        {
            // Arrange
            var buyCommand = this.CreateBuyCommand();

            var product = new Product
            {
                Quantity = quantity
            };

            RepositoryMock.Setup(rm => rm.Get(It.IsAny<Guid>())).Returns(product);
            RepositoryMock.Setup(rm => rm.Update(It.IsAny<Product>())).Returns(product);
            RepositoryMock.Setup(rm => rm.SaveChanges());

            // Act
            buyCommand.Undo();

            // Assert
            Assert.AreEqual(expectedResult, product.Quantity);
        }

        // use when the expected exception could be multiple types
        [TestCase(101, typeof(ArgumentOutOfRangeException))]
        [TestCase(100,typeof(ArgumentOutOfRangeException))]
        public void Undo_QuantityEquals100_RaisedArgumentOutOfRange(int quantity, Type exceptionType)
        {
            // Arrange
            var buyCommand = this.CreateBuyCommand();

            var product = new Product
            {
                Quantity = quantity
            };

            RepositoryMock.Setup(rm => rm.Get(It.IsAny<Guid>())).Returns(product);

            // Act and Assert
            var result = Assert.Throws(exceptionType, () => buyCommand.Undo());
        }
    }
}
