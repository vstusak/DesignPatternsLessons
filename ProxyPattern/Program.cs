//var stream = File.OpenWrite("temp.txt");
//var stream2 = File.OpenWrite("temp.txt");


using _02_ProxyPattern;

//var file = new StupidFile();
//var stream = file.OpenWrite("temp.txt");

IFile smartFile = new SmartProxyFile();
var stream = smartFile.OpenWrite("temp.txt");
var stream2 = smartFile.OpenWrite("temp.txt");
var stream3 = smartFile.OpenWrite("log.txt");






///////////////////////////////////////////////////////
/////Virtual Proxy
/////
///

//DataLoader loader = DataLoader.CreateInstance();
//Console.WriteLine("Initialization finished");
//var data = loader.expensiveResults;
////hromada kodu
//foreach (var item in data)
//{
//    Console.WriteLine(item);
//}

//Console.ReadLine();
////////////////////////////////
/////Lazy Loading
/////

var lazyDataLoader = new LazyDataLoader();
Console.WriteLine("Initialization finished");

var data = lazyDataLoader.expensiveResults;
foreach (var item in data)
{
    Console.WriteLine(item);
}
Console.ReadLine();
