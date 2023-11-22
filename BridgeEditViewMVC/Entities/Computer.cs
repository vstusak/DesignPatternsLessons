namespace BridgeEditViewMVC.Entities
{
    public class Computer
    {
        public string Name { get; set; }
        public string Cpu { get; set; }
        public string Memory { get; set; }
        public string Gpu { get; set; }
        public int Price { get; set; }
    }

    public class ComputerAdapter : IProductAdapter
    {
        public Computer Computer { get; set; }

        public Dictionary<string, string> GetAllInformation()
        {
            var items = new Dictionary<string, string>()
            {
                {"Name", Computer.Name},
                {"Cpu", Computer.Cpu},
                {"Memory", Computer.Memory},
                {"Gpu", Computer.Gpu}
            };
            return items;
        }

        public string GetName()
        {
            return Computer.Name;
        }

        public string GetDescription()
        {
            return $"Powered with {Computer.Cpu}, equipped with {Computer.Memory} and {Computer.Gpu} GPU";
        }

        public int GetPrice()
        {
            return Computer.Price;
        }
    }
}
