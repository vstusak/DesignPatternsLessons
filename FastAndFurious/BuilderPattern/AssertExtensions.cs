using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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
