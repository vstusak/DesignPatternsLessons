using SingletonPattern;

FileLogger.GetInstance().LogToFile("message");

var instanceOne = FileLogger.GetInstance();
var instanceTwo = FileLogger.GetInstance();

var equality = Object.ReferenceEquals(instanceOne, instanceTwo);
instanceOne.LogToFile(equality + nameof(instanceOne));
instanceTwo.LogToFile(equality + nameof(instanceTwo));