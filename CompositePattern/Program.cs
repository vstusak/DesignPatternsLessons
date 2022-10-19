// See https://aka.ms/new-console-template for more information

using CompositePattern;

Console.WriteLine("Hello, World!");

var folder = new MyFolder("Folder 1");
folder.AddItem(new MyFile("Leaf 1", 1));
folder.AddItem(new MyFile("Leaf 2", 2));
folder.AddItem(new MyFile("Leaf 3", 3));



var folder2 = new MyFolder("Folder 2");
folder2.AddItem(folder);
folder2.AddItem(new MyFile("Leaf 4", 1));
folder2.AddItem(new MyFile("Leaf 5", 2));
folder2.AddItem(new MyFile("Leaf 6", 3));


WriteItemToConsole(folder, 6);
WriteItemToConsole(folder2, 12);

folder2.RemoveItem("Leaf 1");
WriteItemToConsole(folder2, 12);

folder2.RemoveItem("Leaf 4");
WriteItemToConsole(folder2, 11);


void WriteItemToConsole(ISystemItem folder, int expectedSize)
{
    Console.WriteLine($"{folder.Name}: Size: {folder.GetSize()}. Expected size: {expectedSize}");
}
