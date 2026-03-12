var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var sqlPassword = builder.AddParameter("sql-password", "CsharpAcademy@2026");
var sqlServer = // @TODO

var apiService = builder.AddProject<Projects.ProductFuriousStore_ApiService>("apiservice")
    .WithHttpHealthCheck("/health");

builder.AddProject<Projects.ProductFuriousStore_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithHttpHealthCheck("/health")
    .WithReference(cache)
    .WaitFor(cache)
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();

// @TODO Create Db for product store
// @TODO Create controlers in API project for product store
// @TODO Create all in web project for product store
