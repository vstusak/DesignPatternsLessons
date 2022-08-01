namespace CompositePattern;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Hello, World!");

        var folder = new Folder("Folder 1");
        folder.AddItem(new File("Leaf 1", 1));
        folder.AddItem(new File("Leaf 2", 2));
        folder.AddItem(new File("Leaf 3", 3));

        var folder2 = new Folder("Folder 2");
        folder2.AddItem(folder);
        folder2.AddItem(new File("Leaf 4", 1));
        folder2.AddItem(new File("Leaf 5", 2));
        folder2.AddItem(new File("Leaf 6", 3));

        WriteItemToConsole(folder, 6);
        WriteItemToConsole(folder2, 12);

        folder2.RemoveItem("Leaf 1");
        WriteItemToConsole(folder2, 12);

        folder2.RemoveItem("Leaf 4");
        WriteItemToConsole(folder2, 11);
    }

    private static void WriteItemToConsole(ISystemItem folder, int expectedSize)
    {
        Console.WriteLine($"{folder.Name}: Size: {folder.GetSize()}. Expected size: {expectedSize}");
    }
}