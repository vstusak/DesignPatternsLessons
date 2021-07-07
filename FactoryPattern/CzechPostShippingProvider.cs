using System.Text;

namespace FactoryPattern
{
    class CzechPostShippingProvider : IShippingProvider
    {
        public string GenerateShippingLabel(DeliveryInfo deliveryInfo) 
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{deliveryInfo.FirstName} {deliveryInfo.LastName}");
            sb.AppendLine($"{deliveryInfo.Address}");
            sb.AppendLine($"Payment: {deliveryInfo.PaymentOptions}");
            return sb.ToString();
        }
    }
}
