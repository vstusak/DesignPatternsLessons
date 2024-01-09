// See https://aka.ms/new-console-template for more information
using Recursion;

Console.WriteLine("Hello, World!");
string rootpath = @"C:\Recursion";

//var directoryGetFiles = Directory.GetDirectories(rootpath);

//foreach (var directory in directoryGetFiles)
//{
//    Console.WriteLine(directory);
//}

//var directoryGetPaths_OldDirectories = Directory.GetDirectories(rootpath,"*", SearchOption.AllDirectories);




//foreach (var directory in directoryGetPaths_OldDirectories)
//{
//    Console.WriteLine(directory);
//    var directoryGetFiles = Directory.GetFiles(directory);

//    foreach (var file in directoryGetFiles)
//    {
//        Console.WriteLine(file);
//    }

//}

var callFolders = new CallFolders();
var result = callFolders.GetAllFiles(rootpath);

foreach (var file in result)
{
    Console.WriteLine(file);
}