using Microsoft.EntityFrameworkCore;
using ProductFuriousStore.ApiService;
using ProductFuriousStore.Logic;
using ProductFuriousStore.Logic.Repo;

var builder = WebApplication.CreateBuilder(args);

// builder.AddSqlServerDbContext<ProductStoreContext>("sqlDb");
builder.Services.AddDbContext<ProductStoreContext>(options => options.UseSqlServer("sqlDb"));
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

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ProductStoreContext>();

    context.Database.EnsureCreated();

    // TODO solve:
    // An unhandled exception of type 'System.ArgumentException' occurred in Microsoft.Data.SqlClient.dll: 
    // 'Format of the initialization string does not conform to specification starting at index 0.'
}

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

