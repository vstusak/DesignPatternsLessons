namespace _02_ProxyPattern
{
    public class LazyDataLoader
    {
        public IEnumerable<ExpensiveResult> expensiveResults => lazyExpensiveResults.Value;
        private Lazy<IEnumerable<ExpensiveResult>> lazyExpensiveResults;
        public LazyDataLoader()
        {
            lazyExpensiveResults = new Lazy<IEnumerable<ExpensiveResult>>(() => DataSource.GetEntities());
            Console.WriteLine("Lazy constructor called");
        }
    }
}
