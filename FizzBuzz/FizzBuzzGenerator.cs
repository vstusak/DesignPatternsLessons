using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz
{
    public class FizzBuzzGenerator
    {
        public string Generate(int start, int iterationCount)
        {
            var result = "";
            for (int i = start; i <= iterationCount + start; i++)
            {
                if (i % 3 == 0)
                    result += "Fizz";
                if (i % 5 == 0)
                    result += "Buzz";
            }
            return result;
        }
    }
}
