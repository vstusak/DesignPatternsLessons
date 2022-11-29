SQLContext context = new SQLContext();

var data = context.LoadData();

var logger = new Logger();
logger.WriteLog(data);
/////////////////////////////////////////////

CosmosDBContext context2 = new CosmosDBContext();

var data2 = context2.GetData();
logger.WriteLog(data2);

