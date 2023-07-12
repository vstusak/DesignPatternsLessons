namespace ObjectChatApplication.Positions;

public class Lawyer : Person
{
    public Lawyer(string name)
    {
        Name = name;
        PositionType = PositionType.Lawyer;
    }
}