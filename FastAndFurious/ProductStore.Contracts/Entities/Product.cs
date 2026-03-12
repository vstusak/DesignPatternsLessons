namespace ProductFuriousStore.Contracts.Entities;

public record Product()
{
    public string Name { get; set; }
    public int Price { get; set; }
    public string Category { get; set; }
}