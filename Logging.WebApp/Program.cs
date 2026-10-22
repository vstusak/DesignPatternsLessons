using ProductStore.WebApi.Client;
using Polly;
using Microsoft.Extensions.Http.Resilience;
using Polly.CircuitBreaker;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddRazorPages();
//builder.Services.AddHttpClient("api", client =>
//{
//    client.BaseAddress = new Uri("https+http://apiservice");
//});
builder.Services.AddHttpClient<IProductStoreApiClient,ProductStoreApiClient>(client =>
{
    client.BaseAddress = new Uri("https+http://apiservice");
})
.RemoveAllResilienceHandlers()
.AddResilienceHandler("standardRetryPipeline", pipeline =>
{
    pipeline.AddRetry(new HttpRetryStrategyOptions
    {
        MaxRetryAttempts = 1, // first standard attempt + retry attempts
        Delay = TimeSpan.FromSeconds(10),
        BackoffType = DelayBackoffType.Exponential,
        UseJitter = true,
        OnRetry = args => {
            Console.WriteLine("Message from our custom resilience handler.");
            return default;
        }
    });
    pipeline.AddCircuitBreaker(new CircuitBreakerStrategyOptions<HttpResponseMessage> { 
        ShouldHandle = args =>
        {
            return ValueTask.FromResult(args is { 
                Outcome.Result.StatusCode: System.Net.HttpStatusCode.RequestTimeout or System.Net.HttpStatusCode.NotFound 
            });
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();


app.Run();