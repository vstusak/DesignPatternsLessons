using ProductFuriousStore.Contracts.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddProblemDetails();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "ProductFuriousStore API v1");
        options.RoutePrefix = string.Empty;
    });
}

//if (app.Environment.IsDevelopment())
//{
//    app.MapOpenApi();
//    app.UseSwaggerUI(options =>
//    {
//        options.SwaggerEndpoint("/openapi/v1.json", "ProductFuriousStore API v1");
//        options.RoutePrefix = string.Empty;
//    });
//}


// TODO create api for product store try both
//  1. minimal api (refactoring)

app.MapGet("/products", () =>
    {
        return Products.Collection;
    })
.WithName("GetProducts");

// TODO add delete button to home.razor
app.MapDelete("/products/{id:int}", (int id) =>
    {
        var product = Products.Collection.FirstOrDefault(product => product.Id == id);

        if (product is null)
        {
            return Results.NotFound();
        }

        Products.Collection.Remove(product);
        return Results.NoContent();
    })
.WithName("DeleteProduct");

app.MapControllers();
app.MapDefaultEndpoints();

app.Run();

/// <summary>
/// Entry point class exposed for integration testing with WebApplicationFactory.
/// </summary>
public partial class Program;

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
