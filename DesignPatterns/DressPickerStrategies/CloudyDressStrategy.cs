namespace DesignPatterns
{
    public class CloudyDressStrategy : IDressStrategy
    {
        public string SuggestPants()
        {
            return "dlouhe kalhoty";
        }

        public string SuggestShoes()
        {
            return "nepromokave boty";
        }
    }

}
