namespace ObjectChatApplication.Positions;

public class Accountant : Person
{
    public Accountant(string name)
    {
        Name = name;
        PositionType = PositionType.Accountant;
    }
}