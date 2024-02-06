using System.Text.Json;

var customer =
    JsonSerializer.Deserialize<CustomerInfo>("""
                                             {"Names":["John Doe"],"Company":{"Name":"Contoso"}}
                                             """)!;

Console.WriteLine(JsonSerializer.Serialize(customer));

internal class CompanyInfo
{
    public required string Name { get; set; }
    public string? PhoneNumber { get; set; }
}

[JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
internal class CustomerInfo
{
    // Both of these properties are read-only.
    public List<string> Names { get; } = new();

    public CompanyInfo Company { get; } = new()
    {
        Name = "N/A",
        PhoneNumber = "N/A"
    };
}