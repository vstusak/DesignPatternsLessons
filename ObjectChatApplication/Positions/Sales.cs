namespace ObjectChatApplication.Positions;

public class Sales : Person
{
    public Sales(string name)
    {
        Name = name;
        PositionType = PositionType.Sales;
    }
}