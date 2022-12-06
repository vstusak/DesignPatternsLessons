public class Logger
{
    public void WriteLog(SQLEntity entity)
    {
        Console.WriteLine($"Name: {entity.Name}, ID: {entity.SQLID}");
    }

    public void WriteLog(DataEntity entity)
    {
        Console.WriteLine($"Name: {entity.Name}, ID: {entity.ID}");
    }
}