
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Time Abstraction");

var otp = new OurTimeProvider();
var ftp = new FakeTimeProvider();
//Console.WriteLine(otp.GetLocalNow());

//var fs = new FirstService(otp);
//var fs2 = new FirstService(ftp);

var serviceCollection = new ServiceCollection();
serviceCollection.AddSingleton<TimeProvider, OurTimeProvider>(TimeProviderType.Real);  //TODO: Solve key problem (keyed singleton missing?)
serviceCollection.AddSingleton<TimeProvider>(new IntTimeProvider(2099));

serviceCollection.AddSingleton<IFirstService, FirstService>();

var service = serviceCollection.BuildServiceProvider();
_ = service.GetService<IFirstService>();


public interface IFirstService
{
}

public class FirstService : IFirstService
{
    public FirstService(TimeProvider tp)
    {
        Console.WriteLine(tp.GetUtcNow());
    }
}

public interface ISecondService
{
}

public class SecondService : ISecondService
{
    public SecondService(TimeProvider tp)
    {
        Console.WriteLine(tp.GetUtcNow());
    }
}


public enum TimeProviderType
{
    Real,
    Fake
}


public class OurTimeProvider : TimeProvider
{

}

public class FakeTimeProvider : TimeProvider
{
    public override DateTimeOffset GetUtcNow()
    {
        return new DateTimeOffset(2024, 1,1,11,36,0, TimeSpan.Zero);
    }

}

public class IntTimeProvider : TimeProvider
{
    public int year { get; set; }

    public IntTimeProvider(int year)
    {
        this.year = year;
    }
    public override DateTimeOffset GetUtcNow()
    {
        return new DateTimeOffset(this.year, 1,1,11,36,0, TimeSpan.Zero);
    }

}