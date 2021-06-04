namespace BuilderPattern
{
    public class Book
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string NumberOfPages { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, ({Author}, {NumberOfPages})";
        }
    }
}