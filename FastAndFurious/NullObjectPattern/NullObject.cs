namespace NullObjectPattern;

public class NullObject : IScienceCalculator
{
    private readonly string? _invalidType;

    public NullObject(string? invalidType)
    {
        _invalidType = invalidType;
    }

    public int Add(int a, int b)
    {
        Console.WriteLine($"Calculator was not correctly loaded with invalid calculator type '{_invalidType}', try again please...");
        return 0;
    }

    public double Sinus(int a)
    {
        Console.WriteLine($"Calculator was not correctly loaded with invalid calculator type '{_invalidType}', try again please...");
        return 0;
    }
}