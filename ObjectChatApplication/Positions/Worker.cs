namespace ObjectChatApplication.Positions;

public class Worker : Person
{
    public Worker(string name)
    {
        Name = name;
        PositionType = PositionType.Worker;
    }
}