using System.Text;

namespace Factory;

public class CzLabelProvider : ILabelProvider
{
    public string RenderLabel(DeliveryInfo deliveryInfo)
    {
        var builder = new StringBuilder();
        builder.AppendLine($"{deliveryInfo.Name} {deliveryInfo.Surname}");
        builder.AppendLine($"{deliveryInfo.Street} {deliveryInfo.StreetNumber}");
        builder.AppendLine($"{deliveryInfo.City}");
        builder.AppendLine($"{deliveryInfo.PostalCode}");
        builder.AppendLine($"{deliveryInfo.Country}");

        return builder.ToString();
    }
}