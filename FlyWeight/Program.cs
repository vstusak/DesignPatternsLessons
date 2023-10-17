// See https://aka.ms/new-console-template for more information
Console.ReadLine();
Console.WriteLine("Hello, World!");
List<Blob> blobs = new List<Blob>();
blobs.Add(new Blob());
blobs.Add(new Blob());
blobs.Add(new Blob());
blobs.Add(new Blob());
blobs.Add(new Blob());
blobs.Add(new Blob());
Console.ReadLine();
//Todo learn memory profilers
class Blob
{
    public Blob()
    {
        Name = Guid.NewGuid().ToString();
        Bytes = new byte[2048*2048];
    }
    string Name { get; set; }
    Byte[] Bytes { get; set; }
}