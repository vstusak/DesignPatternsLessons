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

        [TestCase(1, 20, "1 2 Fizz 4 Buzz Fizz 7 8 Fizz Buzz 11 Fizz 13 14 FizzBuzz 16 17 Fizz 19 Buzz")]
        [TestCase(2, 21, "2 Fizz 4 Buzz Fizz 7 8 Fizz Buzz 11 Fizz 13 14 FizzBuzz 16 17 Fizz 19 Buzz Fizz")]
        public void Generate_InputData_ExpectedResult(int start, int iterationCount, string expectedResult)
        {
            var fizzBuzzGenerator = new FizzBuzzGenerator();

            var actualResult = fizzBuzzGenerator.Generate(start, iterationCount);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}