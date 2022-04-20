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

        [Test]
        public void Execute_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var buyCommand = this.CreateBuyCommand();

            // Act
            buyCommand.Execute();

            // Assert
            Assert.Fail();
        }

        [Test]
        public void Undo_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var buyCommand = this.CreateBuyCommand();

            // Act
            buyCommand.Undo();

            // Assert
            Assert.Fail();
        }
    }
}
