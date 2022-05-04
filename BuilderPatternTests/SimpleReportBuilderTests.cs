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


        [SetUp]
        public void SetUp()
        {

        }

        private SimpleReportBuilder CreateSimpleReportBuilder()
        {
            return new SimpleReportBuilder();
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
            var simpleReportBuilder = CreateSimpleReportBuilder0();

            // Act
            var result = simpleReportBuilder.SetTimeStamp();

            // Assert
            Assert.Fail();
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
