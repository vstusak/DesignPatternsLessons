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
        public string GenerateStringBuilder(string start, string iterationCount)
        {
            var result = new StringBuilder();

            for (int i = Int32.Parse(start); i < Int32.Parse(start) + Int32.Parse(iterationCount); i++)
            {
                result.Append(GetForNumber(i));
                result.Append(" ");
            }
            return result.ToString().TrimEnd();
        }

        public string GenerateStringBuilderWithoutParsing(string start, string iterationCount)
        {
            var startIteration = Int32.Parse(start);
            var iterCount = Int32.Parse(iterationCount);
            var iterCountResult = startIteration + iterCount;
            var result = new StringBuilder();

            for (int i = startIteration; i < iterCountResult; i++)
            {
                result.Append(GetForNumber(i));
                result.Append(" ");
            }
            return result.ToString().TrimEnd();
        }

        public string GenerateStringBuilderWithoutParsingAloc(string start, string iterationCount)
        {
            var startIteration = Int32.Parse(start);
            var iterCount = Int32.Parse(iterationCount);
            var iterCountResult = startIteration + iterCount;
            var result = new StringBuilder(iterCount);

            for (int i = startIteration; i < iterCountResult; i++)
            {
                result.Append(GetForNumber(i));
                result.Append(" ");
            }
            return result.ToString().TrimEnd();
        }

        public string GenerateCollection(string start, string iterationCount)
        {
            var result = new List<string>();

            for (int i = Int32.Parse(start); i < Int32.Parse(start) + Int32.Parse(iterationCount); i++)
            {
                result.Add(GetForNumber(i));
            }
            return string.Join(' ', result);
        }

        public string GenerateString(string start, string iterationCount)
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
