using System.Text;

// @TODO create factory class to create provider

public enum DestinationCountry
{
    Undefined,
    CZ,
    SK,
    GB,
}

public interface ILabelProvider
{
    string RenderLabel(DeliveryInfo deliveryInfo);
}

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

public class SkLabelProvider : ILabelProvider
{
    public string RenderLabel(DeliveryInfo deliveryInfo)
    {
        var builder = new StringBuilder();
        builder.AppendLine($"{deliveryInfo.Name} {deliveryInfo.Surname}");
        builder.AppendLine($"{deliveryInfo.Street} {deliveryInfo.StreetNumber}");
        builder.AppendLine($"{deliveryInfo.PostalCode} {deliveryInfo.City}");
        builder.AppendLine($"{deliveryInfo.Country}");

        return builder.ToString();
    }
}

public class GbLabelProvider : ILabelProvider
{
    public string RenderLabel(DeliveryInfo deliveryInfo)
    {
        var builder = new StringBuilder();
        builder.AppendLine($"{deliveryInfo.Surname} {deliveryInfo.Name}");
        builder.AppendLine($"{deliveryInfo.Street} {deliveryInfo.StreetNumber}");
        builder.AppendLine($"{deliveryInfo.City}");
        builder.AppendLine($"{deliveryInfo.PostalCode}");
        builder.AppendLine($"{deliveryInfo.Country}");

        return builder.ToString();
    }
}