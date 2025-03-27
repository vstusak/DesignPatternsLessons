// vytvorit report/string, bud jednoducha verze (datum + seznam polozek na sklade) anebo full report (+ header + footer)
// builder obsahuje metody ktere urcuji co vytvorit do seznamu
// director rozhoduje jestli jednoducha nebo full verze
// seznam knizek v knihovne

public class Book
{
    public string Author { get; set; }
    public string Name { get; set; }
    public string NumberOfPages { get; set; }

    public override string ToString()
    {
        return $"{Name} ({Author}) - {NumberOfPages}";
    }
}
