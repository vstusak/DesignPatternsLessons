using NUnit.Framework;

namespace BuilderPattern
{
    public static class AssertExtensions
    {

        public static void Is(this string result, string expected)
        {
            Assert.That(result, NUnit.Framework.Is.EqualTo(expected));
        }
    }
}
