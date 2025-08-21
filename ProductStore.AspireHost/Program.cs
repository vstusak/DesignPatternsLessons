//using Aspire.Hosting.SqlServer;
using Redis = Aspire.Hosting.Redis;

var builder = DistributedApplication.CreateBuilder(args);

//var sql = builder.AddSqlServer("sql")
//  .WithDataVolume()
//.AddDatabase("sqldb");
var sqlPassword = builder.AddParameter("sql-password", "Sup€rS€cr€t2499");
var sqlserver = builder.AddSqlServer("sqlserver",password:sqlPassword)
    .WithDataVolume();

var sqlDb = sqlserver.AddDatabase("StoreDb");

 //var addressBookDb = sqlserver.AddDatabase("AddressBook")
   //  .WithCreationScript(File.ReadAllText(initScriptPath));



//TODO: Finalize implementing Aspire on this project ->
//TODO: move data to database in docker, create docker initialization, setup docker to use local volume

//TODO: use cache
//var cache = builder.AddRedis("cache");

//var loader = builder.AddProject<Projects.ProductStore_Loader>("loader");
var apiService = builder.AddProject<Projects.ProductStore_WebApi>("apiservice")
       //.WaitForCompletion(loader);
       .WithReference(sqlserver)
       .WaitFor(sqlserver);

builder.AddProject<Projects.ProductStore_WebApp>("webfrontend")
    .WithExternalHttpEndpoints()
    //.WithReference(cache)
    //.WaitFor(cache)
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();