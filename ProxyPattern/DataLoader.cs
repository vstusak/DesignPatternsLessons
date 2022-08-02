namespace _02_ProxyPattern
{
    public class DataLoader
    {
        //private string myProperty2;

        private string _text; //TODO - Show inicialization of object

        public virtual IEnumerable<ExpensiveResult> expensiveResults { get; protected set; }

        protected DataLoader()
        {
            Console.WriteLine($"Constructor [DataLoader] has been loaded.");
        }

        //public string MyProperty { get; set; }
        //public string MyProperty2
        //{
        //    get
        //    {
        //        return myProperty2;
        //    }
        //    set
        //    {
        //        myProperty2 = value;
        //    }
        //}

        public static DataLoader CreateInstance() 
        { 
            return new VirtualProxyDataLoader(); 
        }
    }
}
