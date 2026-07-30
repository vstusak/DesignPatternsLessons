using ProductFuriousStore.Contracts.Entities;

namespace ProductFuriousStore.Logic;

public static class Products
{
    public static List<Product> Collection { get; private set; } = CreateSeed();

    public static void Reset()
    {
        Collection = CreateSeed();
    }

    private static List<Product> CreateSeed() =>
        [
            new()
            {
                Id = 1,
                Name = "Product 1",
                Category = "Category 1",
                Price = 10
            },
            new()
            {
                Id = 2,
                Name = "Product 2",
                Category = "Category 2",
                Price = 20
            },
            new()
            {
                Id = 3,
                Name = "Product 3",
                Category = "Category 3",
                Price = 30
            }

        ];
}
