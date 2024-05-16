//RealTimeProvider _realTimeProvider = new RealTimeProvider();
//FakeTimeProvider _fakeTimeProvider = new FakeTimeProvider();
//TimeProvider _timeProvider = TimeProvider.System;
//Console.WriteLine($"real time is: {_realTimeProvider.GetUtcNow()}");
//Console.WriteLine($"system time is: {_timeProvider.GetUtcNow()}");
//Console.WriteLine($"fake time is: {_fakeTimeProvider.GetUtcNow()}");

//public class RealTimeProvider : TimeProvider
//{

//}

//public class FakeTimeProvider : TimeProvider
//{
//    public override DateTimeOffset GetUtcNow()
//    {
//        return new DateTimeOffset(2024, 1, 1,3,15,05,TimeSpan.Zero);
//    }
//}