using CQRS;
using Moq;
using NUnit.Framework;
using System;
using RepositoryPattern.Context;

namespace RepositoryPattern.Tests
{
    [TestFixture]
    public class ProductDetailQueryHandlerTests : TestsBase
    {

        private Mock<IRepository<Product>> mockProductRepository;

        [SetUp]
        public void SetUp()
        {
            mockProductRepository = MockRepo.Create<IRepository<Product>>();
        }

        private ProductDetailQueryHandler CreateProductDetailQueryHandler()
        {
            return new ProductDetailQueryHandler(
                mockProductRepository.Object);
        }

        [Test]
        public void Execute_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var product = new Product()
            {
                Name = "Test Product",
            };
            var query = new ProductDetailQuery()
            {
                ProductId = Guid.NewGuid()
            };

            mockProductRepository.Setup(mpr => mpr.Get(It.IsAny<Guid>())).Returns(product);
            
            var unit = CreateProductDetailQueryHandler();

            // Act
            var result = unit.Execute(
                query);

            // Assert
            Assert.AreEqual(product, result);
        }
    }
}
