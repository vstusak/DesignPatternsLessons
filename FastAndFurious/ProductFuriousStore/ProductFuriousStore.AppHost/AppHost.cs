var builder = DistributedApplication.CreateBuilder(args);

//var cache = builder.AddRedis("cache");

var sqlPassword = builder.AddParameter("sql-password", "CsharpAcademy@2026");

var sqlServer = builder.AddSqlServer("fastfurioussqlserver", sqlPassword)
    .WithImageTag("2025-latest")
    .WithDataVolume()
    .WithLifetime(ContainerLifetime.Persistent)
    .WithContainerName("productStoreSql")
    //.WithEndpoint(name:"ssms", port: 1433, targetPort: 1433 )
    ;

var sqlDb = sqlServer.AddDatabase("productstoredb");
 

var apiService = builder.AddProject<Projects.ProductFuriousStore_ApiService>("apiservice")
    .WithHttpHealthCheck("/health")
    .WithReference(sqlDb)
    .WaitForCompletion(sqlDb);

builder.AddProject<Projects.ProductFuriousStore_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithHttpHealthCheck("/health")
    //.WithReference(cache)
    //.WaitFor(cache)
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();  

// @TODO Create controlers in API project for product store
// @TODO Create all in web project for product store

