using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace FizzBuzz
{
    public class FizzBuzzGenerator
    {
        public string Generate(string start, string iterationCount)
        {
            var result = "";

            
            for (int i = Int32.Parse(start); i < Int32.Parse(start) + Int32.Parse(iterationCount); i++)
            {
                result += GetForNumber(i) + " ";
            }
            return result.TrimEnd();
        }

        public string GetForNumber(int number)
        {
            if ( number % 3 == 0 && number % 5 == 0)
                return "FizzBuzz";

            if (number % 3 == 0)
                return "Fizz";

            if (number % 5 == 0)
                return "Buzz";
            
            return number.ToString();
        }
    }
}
