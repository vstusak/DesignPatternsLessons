namespace _02_ProxyPattern
{
    public class DataLoader
    {
        public IEnumerable<ExpensiveResult> expensiveResults => DataSource.GetEntities();
    }
}
