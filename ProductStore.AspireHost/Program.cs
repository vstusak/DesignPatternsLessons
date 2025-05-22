var builder = DistributedApplication.CreateBuilder(args);

//TODO: Finalize implementing Aspire on this project ->
//TODO: move data to database in docker, create docker initialization, setup docker to use local volume

//TODO: use cache
//var cache = builder.AddRedis("cache");

var loader = builder.AddProject<Projects.ProductStore_Loader>("loader");

var apiService = builder.AddProject<Projects.ProductStore_WebApi>("apiservice").WaitForCompletion(loader);

builder.AddProject<Projects.ProductStore_WebApp>("webfrontend")
    .WithExternalHttpEndpoints()
    //.WithReference(cache)
    //.WaitFor(cache)
    .WithReference(apiService)
    .WaitFor(apiService);
    //TODO: Check how WaitFor is handled (healthchecks, etc.)

builder.Build().Run();