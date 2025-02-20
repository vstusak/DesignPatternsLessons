namespace NullObjectPattern;

public class ScienceCalculator : IScienceCalculator
{
    public double Sinus(int a)
    {
        return Math.Sin(a);
    }

    public int Add(int a, int b)
    {
        return a + b;
    }
}