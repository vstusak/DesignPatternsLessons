namespace BridgeEditViewMVC.Entities
{
    public interface IProductAdapter
    {
        Dictionary<string, string> GetAllInformation();

        string GetName();
        string GetDescription();
        int GetPrice();
    }
}
