namespace FactoryPattern
{
    public interface IShippingProvider
    {
        string GenerateShippingLabel(DeliveryInfo deliveryInfo);
    }
}
