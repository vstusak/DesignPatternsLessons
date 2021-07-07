using System.Text;

namespace FactoryPattern
{
    class SlovakPostShippingProvider : IShippingProvider
    {
        public string GenerateShippingLabel(DeliveryInfo deliveryInfo) 
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{deliveryInfo.LastName} {deliveryInfo.FirstName}");
            sb.AppendLine($"{deliveryInfo.Address}");
            sb.AppendLine($"Payment: {deliveryInfo.PaymentOptions}");
            sb.AppendLine($"Tax: {deliveryInfo.Tax}");
            return sb.ToString();
        }
    }
}
