namespace VisitorPattern.Products;

public class Book : IProduct
{
    public string Name { get; set; }
    public int Price { get; set; }
}