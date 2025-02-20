namespace NullObjectPattern;

public class Calculator : ICalculator
{
    public virtual int Add(int a, int b)
    {
        return a + b;
    }
}