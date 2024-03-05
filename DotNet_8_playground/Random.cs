ReadOnlySpan<Button> s_allButtons = new[]
{
    Button.Red,
    Button.Green,
    Button.Blue,
    Button.Yellow,
};

Button[] thisRound = Random.Shared.GetItems(s_allButtons, 31);

foreach (Button button in thisRound)
{
    Console.WriteLine(button);
}
public enum Button
{
    Red,Green,Blue,Yellow
}