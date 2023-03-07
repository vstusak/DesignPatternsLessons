using SingletonDesignPattern;

var i = FileAccessSingleton.GetInstance();
var j = FileAccessSingleton.GetInstance();
Console.WriteLine(object.ReferenceEquals(i, j));

var k = FileAccessSingleton.GetInstance();
Console.WriteLine(object.ReferenceEquals(i,k));

