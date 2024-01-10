using System.Text.Json;
using System.Text.Json.Serialization;

//TODO: Continue on 'Disable reflection-based default' (https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-8)


CustomerInfo customer =
    JsonSerializer.Deserialize<CustomerInfo>("""
                                             {"Names":["John Doe"],"Company":{"Name":"Contoso"}}
                                             """)!;

Console.WriteLine(JsonSerializer.Serialize(customer));

class CompanyInfo
{
    public string Name { get; set; }
    //public required string Name { get; set; }
    public string? PhoneNumber { get; set; }
}

[JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
class CustomerInfo
{
    // Both of these properties are read-only.
    public List<string> Names { get; } = new();
    public CompanyInfo Company { get; } = new()
    {
        Name = "N/A", PhoneNumber = "N/A"
    };
}