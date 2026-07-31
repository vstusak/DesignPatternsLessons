using ProductFuriousStore.ApiService;
using ProductFuriousStore.Contracts.Entities;
using ProductFuriousStore.Logic;
using ProductFuriousStore.Logic.Repo;

var builder = WebApplication.CreateBuilder(args);

//builder.AddSqlServerDbContext<ProductStoreContext>("sqlDb");

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddProblemDetails();
builder.Services.AddScoped<IProductRepo, ProductRepo>();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddMinimalApiDefaultEndpoints(typeof(Program).Assembly);

// @TODO IEndpoint implemented - try if it works
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

app.MapMinimalApiDefaultEndpoints();
app.MapControllers();
app.MapDefaultEndpoints();

app.Run();

