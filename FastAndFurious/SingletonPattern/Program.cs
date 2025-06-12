
using SingletonPattern;

FileLogger.GetInstance().LogToFile("message");

var instanceOne = FileLogger.GetInstance();
var instanceTwo = FileLogger.GetInstance();

var equality = Object.ReferenceEquals(instanceOne, instanceTwo);
instanceOne.LogToFile(equality.ToString());
instanceTwo.LogToFile(equality.ToString());

// todo final file is fucked, please solve, bye