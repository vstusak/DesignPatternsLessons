using Microsoft.Extensions.Hosting;
using System.Net.Http;
using ProductStore.WebApi.Client;
using ProductStore.WebApp;

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
});

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
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