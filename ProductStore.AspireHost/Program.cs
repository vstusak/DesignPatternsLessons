//using Aspire.Hosting.SqlServer;
using Redis = Aspire.Hosting.Redis;

var builder = DistributedApplication.CreateBuilder(args);

//var sql = builder.AddSqlServer("sql")
//    .WithDataVolume()
//    .AddDatabase("sqldb");

//TODO: Tady Milan skoncil, password nelze vlozit (mlati se s Redisem?)
var sql = builder
        .AddSqlServer("sql")
        .WithPassword(password: "password123")
    //.WithDataBindMount(@"C:\SqlServer\Data", false)
    //.WithEndpoint(port:6033, targetPort:1433, name:"ssms")
    //.WithLifetime(ContainerLifetime.Persistent)
    //.WithContainerName<SqlServerServerResource>("sqlserver")
    ;

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

builder.Build().Run();