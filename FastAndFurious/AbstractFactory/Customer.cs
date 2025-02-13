namespace AbstractFactory;

public class Customer
{
    public string Name { get; set; }
    public int CustomerId { get; set; }

    public CustomerType CustomerType { get; set; }
}

public enum CustomerType
{
    Undefined,
    Regular,
    RegularSavings,
    Authorized,
    Businessman
}