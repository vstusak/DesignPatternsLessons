//var stream = File.OpenWrite("temp.txt");
//var stream2 = File.OpenWrite("temp.txt");


using _02_ProxyPattern;

//var file = new StupidFile();
//var stream = file.OpenWrite("temp.txt");

var smartFile = new SmartProxyFile();
var stream = smartFile.OpenWrite("temp.txt");
var stream2 = smartFile.OpenWrite("temp.txt");
var stream3 = smartFile.OpenWrite("log.txt");
