namespace NullObjectPattern;

public class CalculatorFactory
{
    public ICalculator Create(string type)
    {
        return type switch
        {
            "standard" => new Calculator(),
            "science" => new ScienceCalculator(),
            _ => new NullObject(type),
        };
    }
}