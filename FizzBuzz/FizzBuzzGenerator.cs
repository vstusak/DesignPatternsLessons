namespace FizzBuzz
{
    public class FizzBuzzGenerator
    {
        private const int CountOfMembers = 20;
        public string GetSequence(string input)
        {
            var inputNumber = Int32.Parse(input);
            var sequence = new List<string>();
            for (int i = inputNumber; i < CountOfMembers + inputNumber; i++)
            {
                sequence.Add(ResolveNumber(i));
            }
            return String.Join(' ', sequence);
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
