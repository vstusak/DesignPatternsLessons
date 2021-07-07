namespace FactoryPattern
{
    public class ShoppingCart
    {
        private readonly IShippingProviderFactory _shippingProviderFactory;

        public ShoppingCart(IShippingProviderFactory shippingProviderFactory)
        {
            _shippingProviderFactory = shippingProviderFactory;
        }

        public string FinalizeOrder(string DestinationCountry, string ShippingProvider)
        {
            var deliveryInfo = new DeliveryInfo("Dežo", "Lakatoš", "Slovenská 654, 85622, Nové Zámky-Štůrovo", "Paid during delivery", 35);

            var shippingProvider = _shippingProviderFactory.Get(DestinationCountry);
            return shippingProvider.GenerateShippingLabel(deliveryInfo);

            //if (DestinationCountry == "CR")
            //{
            //    CzechPostShippingProvider czechProvider = new CzechPostShippingProvider("Lojza", "Klikař", "Úvoz 10, 60200, Brno", "Prepaid");
            //    return czechProvider.GenerateShippingLabel();
            //}
            //else if (DestinationCountry == "SK")
            //{
            //    SlovakPostShippingProvider slovakProvider = new SlovakPostShippingProvider("Dežo", "Lakatoš", "Slovenská 654, 85622, Nové Zámky-Štůrovo", "Paid during delivery", 35);
            //    return slovakProvider.GenerateShippingLabel();
            //}
            //else
            //{
            //    throw new Exception("Unknown destination country");
            //}
        }
    }
}
