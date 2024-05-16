namespace TestBox
{
    public class KeyWordFactory
    {
        public IKeyWord GetKeyWord(string name)
        {
            switch (name)
            {
                case "Click" : return new Click();
                case "Search": return new Click();
                default : return null; 
            }
        }

    }
}
