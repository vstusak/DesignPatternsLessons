//using Aspire.Hosting.SqlServer;
//using Redis = Aspire.Hosting.Redis;

var builder = DistributedApplication.CreateBuilder(args);

//var sql = builder.AddSqlServer("sql")
//  .WithDataVolume()
//.AddDatabase("sqldb");
var sqlPassword = builder.AddParameter("sql-password", "Sup€rS€cr€t2499");
var sqlserver = builder.AddSqlServer("sqlserver", password:sqlPassword)
    .WithDataVolume();

var sqlDb = sqlserver.AddDatabase("StoreDb");


//DONE: Finalize implementing Aspire on this project ->
//DONE: move data to database in docker, create docker initialization, setup docker to use local volume
//TODO: Create entity framework migrations

//TODO: use cache
//var cache = builder.AddRedis("cache");

//var loader = builder.AddProject<Projects.ProductStore_Loader>("loader"); //Testing to try waiting for completion 2 rows bellow
var apiService = builder.AddProject<Projects.ProductStore_WebApi>("apiservice")
       //.WaitForCompletion(loader);
       .WithReference(sqlDb)
       .WaitFor(sqlDb);

builder.AddProject<Projects.ProductStore_WebApp>("webfrontend")
    .WithExternalHttpEndpoints()
    //.WithReference(cache)
    //.WaitFor(cache)
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();