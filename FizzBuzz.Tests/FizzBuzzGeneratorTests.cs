using NUnit.Framework;

namespace FizzBuzz.Tests
{
    public class FizzBuzzGeneratorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("1", "1 2 Fizz 4 Buzz Fizz 7 8 Fizz Buzz 11 Fizz 13 14 FizzBuzz 16 17 Fizz 19 Buzz")]
        [TestCase("5", "Buzz Fizz 7 8 Fizz Buzz 11 Fizz 13 14 FizzBuzz 16 17 Fizz 19 Buzz Fizz 22 23 Fizz")]
        public void Test1(string input, string expected)
        {
            var unitUnderTest = new FizzBuzzGenerator();
            var result = unitUnderTest.GetSequence(input);

            Assert.AreEqual(expected, result);
        }
    }
}