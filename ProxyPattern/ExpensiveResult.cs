namespace _02_ProxyPattern
{
    public class ExpensiveResult
    {
        public string Text { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
