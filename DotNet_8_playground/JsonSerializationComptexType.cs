using System.Text.Json.Serialization;
using System.Text.Json;

string json = JsonSerializer.Serialize(new MyPoco(42));
// {"X":42}

JsonSerializer.Deserialize<MyPoco>(json);

public class MyPoco
{
    [JsonConstructor]
    internal MyPoco(int x) => X = x;

    [JsonInclude]
    internal int X { get; }
}

// ToDo https://web.archive.org/web/20240124050045/https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-8