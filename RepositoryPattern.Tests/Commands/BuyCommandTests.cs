using Moq;
using NUnit.Framework;
using RepositoryPattern;
using RepositoryPattern.Commands;
using RepositoryPattern.Context;
using System;

namespace RepositoryPattern.Tests.Commands
{
    [TestFixture]
    public class BuyCommandTests : TestsBase
    {
        private Product product;
        private Mock<IRepository<Product>> mockRepository;

        [SetUp]
        public void SetUp()
        {
            product = new Product();
            mockRepository = MockRepo.Create<IRepository<Product>>();
        }

        private BuyCommand CreateBuyCommand()
        {
            return new BuyCommand(
                product,
                mockRepository.Object);
        }

        [TestCase(1,true)]
        [TestCase(0, false)]
        public void CanExecute_SetQuantity_ReturnsExpected(int quantity, bool expectedResult)
        {
            // Arrange
            product.Quantity = quantity;
            mockRepository.Setup(prm => prm.Get(It.IsAny<Guid>())).Returns(product);
            
            var buyCommand = CreateBuyCommand();

            // Act
            var result = buyCommand.CanExecute();

            // Assert
            Assert.AreEqual(expectedResult,result);
        }

        [Test]
        public void Execute_QuantityAllowingDecretion_UpdateHasBeenCalled()
        {
            // Arrange
            product.Quantity = 10;
            var buyCommand = CreateBuyCommand();
            mockRepository.Setup(prm => prm.Get(It.IsAny<Guid>())).Returns(product);
            mockRepository.Setup(prm => prm.Update(It.IsAny<Product>())).Returns(product);

            // Act
            buyCommand.Execute();

            // Assert
            mockRepository.Verify(prm => prm.Update(It.IsAny<Product>()), Times.Once);
        }

        [Test]
        public void Execute_QuantityAllowingDecretion_QuantityDecresed()
        {
            // Arrange
            product.Quantity = 10;
            var buyCommand = CreateBuyCommand();
            mockRepository.Setup(prm => prm.Get(It.IsAny<Guid>())).Returns(product);
            mockRepository.Setup(prm => prm.Update(It.IsAny<Product>())).Returns(product);

            // Act
            buyCommand.Execute();

            // Assert
            Assert.AreEqual(9, product.Quantity);
        }

        [Test]
        public void Undo_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var buyCommand = CreateBuyCommand();

            // Act
            buyCommand.Undo();

            // Assert
            Assert.Fail();
        }
    }
}
