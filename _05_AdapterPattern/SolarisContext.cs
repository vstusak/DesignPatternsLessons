namespace _05_AdapterPattern;

public class SolarisContext
{
    public SolarisEntity FindData()
    {
        return new SolarisEntity { Name = "Dan", SolarisID = 3 };
    }
}
