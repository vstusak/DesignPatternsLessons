namespace BridgeEditViewMVC.Models;

public class FormItem
{
    public string PropertyName { get; set; }
    public string PropertyValue { get; set; }
    public string PropertyType { get; set; }

    public FormItem(string propertyName, string propertyValue, string propertyType)
    {
        PropertyName = propertyName;
        PropertyValue = propertyValue;
        PropertyType = propertyType;
    }

    public FormItem()
    {
        PropertyName = string.Empty;
        PropertyValue = string.Empty;
        PropertyType = string.Empty;
    }
}