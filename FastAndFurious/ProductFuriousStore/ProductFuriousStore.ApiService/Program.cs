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
        var products = new List<Product>()
        {
            new()
            {
                Name = "Product 1",
                Category = "Category 1",
                Price = 10
            },
            new()
            {
                Name = "Product 2",
                Category = "Category 2",
                Price = 20
            },
            new()
            {
                Name = "Product 3",
                Category = "Category 3",
                Price = 30
            }

        };
    return products;
})
.WithName("GetProducts");

app.MapControllers();
app.MapDefaultEndpoints();

app.Run();

/// <summary>
/// Entry point class exposed for integration testing with WebApplicationFactory.
/// </summary>
public partial class Program;
