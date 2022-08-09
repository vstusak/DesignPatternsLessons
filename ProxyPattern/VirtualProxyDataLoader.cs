namespace _02_ProxyPattern
{
    public class VirtualProxyDataLoader : DataLoader
    {
        public VirtualProxyDataLoader()
        {
            Console.WriteLine($"Constructor [VirtualProxyDataLoader] has been loaded.");
        }

        public override IEnumerable<ExpensiveResult> expensiveResults
        {
            get
            {
                if (base.expensiveResults == null)
                {
                    base.expensiveResults = DataSource.GetEntities();
                    Console.WriteLine("text");
                }
                return base.expensiveResults;
            }
            protected set
            {
                base.expensiveResults = value;
            }
        }

    }
}
