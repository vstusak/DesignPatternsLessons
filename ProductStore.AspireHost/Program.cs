var builder = DistributedApplication.CreateBuilder(args);

//TODO: Finalize implementing Aspire on this project

//var cache = builder.AddRedis("cache");

var apiService = builder.AddProject<Projects.ProductStore_WebApi>("apiservice");

builder.AddProject<Projects.ProductStore_WebApp>("webfrontend")
    .WithExternalHttpEndpoints()
    //.WithReference(cache)
    //.WaitFor(cache)
    .WithReference(apiService)
    .WaitFor(apiService);
    //TODO: Check how WaitFor is handeled (healthchecks, etc.)

builder.Build().Run();