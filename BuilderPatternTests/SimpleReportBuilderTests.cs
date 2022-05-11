using BuilderPattern;
using Moq;
using NUnit.Framework;
using RepositoryDesignPatternTests;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BuilderPatternTests
{
    [TestFixture]
    public class SimpleReportBuilderTests : TestBase
    {
        private Mock<IDateTimeProvider> _timeProviderMock;

        [SetUp]
        public void SetUp()
        {
            _timeProviderMock = MockRepository.Create<IDateTimeProvider>();
        }

        private SimpleReportBuilder CreateSimpleReportBuilder()
        {
            return new SimpleReportBuilder(_timeProviderMock.Object);
        }

        [Test]
        public void Reset_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var simpleReportBuilder = CreateSimpleReportBuilder();

            // Act
            var result = simpleReportBuilder.Reset();

            // Assert
            Assert.Fail();
        }

        [Test]
        public void SetHeader_EmptyReport_HeaderIncluded()
        {
            // Arrange
            var simpleReportBuilder = CreateSimpleReportBuilder();
            //var stringBuilder = new object();
            //SimpleReportBuilder test = (SimpleReportBuilder)stringBuilder;

            // Act
            SimpleReportBuilder result = simpleReportBuilder.SetHeader() as SimpleReportBuilder;

            // Assert
            Assert.AreEqual($"Header{Environment.NewLine}", result?._report.ToString());
        }

        [Test]
        public void SetAddress_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var simpleReportBuilder = CreateSimpleReportBuilder();
            string address = null;

            // Act
            var result = simpleReportBuilder.SetAddress(
                address);

            // Assert
            Assert.Fail();
        }

        [Test]
        public void CreateList_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var simpleReportBuilder = CreateSimpleReportBuilder();
            IEnumerable<Book> books = null;

            // Act
            var result = simpleReportBuilder.CreateList(
                books);

            // Assert
            Assert.Fail();
        }

        [Test]
        public void SetTimeStamp_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var simpleReportBuilder = CreateSimpleReportBuilder();
            DateTime expectedDateTime = new DateTime(2022, 05, 25, 17, 30, 00);
            _timeProviderMock.Setup(tpm => tpm.Now).Returns(expectedDateTime);

            // Act
            SimpleReportBuilder result = simpleReportBuilder.SetTimeStamp() as SimpleReportBuilder;

            // Assert
            Assert.AreEqual($"{expectedDateTime.ToString()}{Environment.NewLine}", result?._report.ToString());
        }

        [Test]
        public void SetFooter_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var simpleReportBuilder = CreateSimpleReportBuilder();

            // Act
            var result = simpleReportBuilder.SetFooter();

            // Assert
            Assert.Fail();
        }

        [Test]
        public void Build_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var simpleReportBuilder = CreateSimpleReportBuilder();

            // Act
            var result = simpleReportBuilder.Build();

            // Assert
            Assert.Fail();
        }
    }
}
