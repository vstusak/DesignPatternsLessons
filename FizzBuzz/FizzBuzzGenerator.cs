using System.Text;

namespace FizzBuzz
{
    public class FizzBuzzGenerator
    {
        private const int CountOfMembers = 20000;
        public string GetSequence(string input)
        {
            var inputNumber = ParseInput(input);
            var sequence = new List<string>();
            for (var i = inputNumber; i < CountOfMembers + inputNumber; i++)
            {
                sequence.Add(ResolveNumber(i));
            }
            return String.Join(' ', sequence);
        }

        public string GetSequenceStringJoin(string input)
        {
            var inputNumber = ParseInput(input);
            var sequence = new List<string>();
            for (var i = inputNumber; i < CountOfMembers + inputNumber; i++)
            {
                sequence.Add(ResolveNumber(i));
            }
            return String.Join(' ', sequence);
        }

        public string GetSequenceStrings(string input)
        {
            var inputNumber = ParseInput(input);
            var result = String.Empty;
            for (var i = inputNumber; i < CountOfMembers + inputNumber; i++)
            {
                result = result + ResolveNumber(i) + " ";
            }
            return result.TrimEnd();
        }

        public string GetSequenceStringBuilder(string input)
        {
            var inputNumber = ParseInput(input);
            var stringBuilder = new StringBuilder(20000);
            for (var i = inputNumber; i < CountOfMembers + inputNumber; i++)
            {
                stringBuilder.Append(ResolveNumber(i));
                stringBuilder.Append(' ');
            }
            return stringBuilder.ToString().TrimEnd();
        }

        private int ParseInput(string input)
        {
            if (int.TryParse(input, out var result))
            {
                return result;
            }
            throw new ArgumentException($"Wrong value of {nameof(input)}");
        }

        private string ResolveNumber(int input)
        {
            if (input % 3 == 0 && input % 5 == 0)
            {
                return "FizzBuzz";
            }
            else if (input % 3 == 0)
            {
                return "Fizz";
            }
            else if (input % 5 == 0)
            {
                return "Buzz";
            }
            else
            {
                return input.ToString();
            }
        }
    }
}
