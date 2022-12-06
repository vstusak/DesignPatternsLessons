using _05_AdapterPattern;

SQLContext context = new SQLContext();

var data = context.LoadData();

var logger = new Logger();
logger.WriteLog(data);
/////////////////////////////////////////////

CosmosDBContext context2 = new CosmosDBContext();

var data2 = context2.GetData();
//logger.WriteLog(data2);
//////////////////////////////////////////////
///
IDbClient client = new CosmosDBContextAdapter(); //misa wants this naming!

var data3 = client.SomeMethod();
logger.WriteLog(data3);
//TODO: IOC + DataEntityObjectInit.