namespace BridgeEditViewMVC.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public int Price { get; set; }
    }

    public class BookAdapter:IProductAdapter
    {
        public Book Book { get; set; }

        public Dictionary<string, string> GetAllInformation()
        {
            var items = new Dictionary<string, string>()
            {
                {"Title", Book.Title},
                {"Author", Book.Author},
                {"Publisher", Book.Publisher},
            };
            return items;
        }

        public string GetName()
        {
            return Book.Title;
        }

        public string GetDescription()
        {
            return $"{Book.Title} by {Book.Author}, published by {Book.Publisher}";
        }

        public int GetPrice()
        {
            return Book.Price;
        }
    }
}
