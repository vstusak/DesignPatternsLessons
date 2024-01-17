using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Net8newFeatures
{
    public static class SerializeJson
    {
        public static void Serialize()
        {
            string json = JsonSerializer.Serialize(new MyPoco(42));
            // {"X":42}

            var deserialized = JsonSerializer.Deserialize<MyPoco>(json);

        }

    }

    public class MyPoco
    {
        [JsonConstructor]
        internal MyPoco(int x) => X = x;

        [JsonInclude]
        internal int X { get; }
    }

}
