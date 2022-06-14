namespace BeforeBridgePattern.Models
{
    public interface IProduct
    {
        public string GetDescription();
    }

    public class Toy
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public string Age { get; set; }
    }

    public class Book
    {
        public string Pages { get; set; }
        public string Author { get; set; }
        public string CoverText { get; set; }
        public string Genre { get; set; }
        public string Title { get; set; }
    }

    public class Computer
    {
        public string Storage { get; set; }
        public string Memory { get; set; }
        public string Processor { get; set; }
        public string Type { get; set; }
    }

    public class Appliance
    {

    }

    public class Car
    {

    }
}
