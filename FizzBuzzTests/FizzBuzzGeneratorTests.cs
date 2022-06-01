using System;
using FizzBuzz;
using NUnit.Framework;

namespace FizzBuzzTests
{
    public class FizzBuzzGeneratorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("1", "20", "1 2 Fizz 4 Buzz Fizz 7 8 Fizz Buzz 11 Fizz 13 14 FizzBuzz 16 17 Fizz 19 Buzz")]
        [TestCase("2", "21", "2 Fizz 4 Buzz Fizz 7 8 Fizz Buzz 11 Fizz 13 14 FizzBuzz 16 17 Fizz 19 Buzz Fizz 22")]
        public void Generate_InputData_ExpectedResult(string start, string iterationCount, string expectedResult)
        {
            var fizzBuzzGenerator = new FizzBuzzGenerator();

            var actualResult = fizzBuzzGenerator.GenerateString(start, iterationCount);

            Assert.AreEqual(expectedResult, actualResult);
        }


        [Test]
        public void Generate_NoNumericStart_FormatExceptionRaised()
        {
            var fizzBuzzGenerator = new FizzBuzzGenerator();
            Assert.Throws<FormatException>(() => fizzBuzzGenerator.GenerateString("Jedna", "5"));
        }


        [TestCase(1,"1")]
        [TestCase(3, "Fizz")]
        [TestCase(5, "Buzz")]
        [TestCase(15, "FizzBuzz")]
        public void GetForNumber_InputData_ExpectedResult(int number, string expectedResult)
        {
            var fizzBuzzGenerator = new FizzBuzzGenerator();

            var actualResult = fizzBuzzGenerator.GetForNumber(number);

            Assert.AreEqual(expectedResult, actualResult);
        }

    }
}