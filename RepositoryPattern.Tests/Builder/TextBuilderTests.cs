using System;
using BuilderPattern;
using BuilderPattern.Builder;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace RepositoryPattern.Tests.Builder
{
    [TestFixture]
    public class TextBuilderTests : TestsBase
    {

        private IEnumerable<Book> _books;

        [SetUp]
        public void SetUp()
        {
            _books = new List<Book>
            {
                new(){Author = "Robert C. Martin", Name = "Clean Code", NumberOfPages = "324"},
                new(){Author = "Carlton Mellic", Name = "The hunted vagina", NumberOfPages = "250"},
                new(){Author = "Dominic Dan", Name = "Popol všetkych zarovna", NumberOfPages = "netusim"},
                new(){Author = "J. K. Rowling", Name = "Harry Potter", NumberOfPages = "hrozne moc"},
                new(){Author = "Aaron Dembski-Bowden", Name = "Helsreach", NumberOfPages = "416"},
                new(){Author = "J. K. Rowling", Name = "Harry Potter # 2", NumberOfPages = "ještě víc"},
            };
        }

        private TextBuilder CreateTextBuilder()
        {
            return new TextBuilder(_books);
        }

        [Test]
        public void SetHeader_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var expectedResult = "Welcome to our library, there is a list of books." + Environment.NewLine;
            var unit = CreateTextBuilder();

            // Act
            var result = unit.SetHeader() as TextBuilder;

            // Assert
            var innerString = result._result.ToString();
            Assert.AreEqual(expectedResult, innerString);
        }

        [Test]
        public void WriteLibrary_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unit = CreateTextBuilder();

            // Act
            var result = unit.WriteLibrary();

            // Assert
            Assert.Fail();
        }

        [Test]
        public void SetFooter_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unit = CreateTextBuilder();

            // Act
            var result = unit.SetFooter();

            // Assert
            Assert.Fail();
        }

        [Test]
        public void AddDateStamp_StateUnderTest_ExpectedBehavior()
        {
            OTESTOVAT
            // Arrange
            var unit = CreateTextBuilder();

            // Act
            var result = unit.AddDateStamp();

            // Assert
            Assert.Fail();
        }

        [Test]
        public void Build_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unit = CreateTextBuilder();

            // Act
            var result = unit.Build();

            // Assert
            Assert.Fail();
        }
    }
}
