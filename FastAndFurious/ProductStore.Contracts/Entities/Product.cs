namespace ProductFuriousStore.Contracts.Entities;

public record Product()
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public string Category { get; set; }
}