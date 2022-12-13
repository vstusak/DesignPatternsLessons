using _05_AdapterPattern;

SQLContext sqlContext = new SQLContext();

var logger = new Logger();
CosmosDBContext cosmosDbContext = new CosmosDBContext();
IDbClient client = new CosmosDBContextAdapter(cosmosDbContext); //misa wants this naming!

/////////////////////////////////////////////
/////////////////////////////////////////////
/////////////////////////////////////////////

//using SQLContext directly and using SQLDataEntity for writing log
//main disadvantage: cannot be replaced by different  or entity

var data = sqlContext.LoadData();

logger.WriteLog(data);
/////////////////////////////////////////////

//same issue as for SQLContext, logger cannot accept different entity than SQLEntity
var data2 = cosmosDbContext.GetData();
//logger.WriteLog(data2);
//////////////////////////////////////////////
///
//solution: using adapter design pattern. We set up common object and entity object

var data3 = client.SomeMethod();
logger.WriteLog(data3);
