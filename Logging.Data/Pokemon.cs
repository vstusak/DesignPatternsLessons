using System.Text.Json.Serialization;
using Logging.Data.enums;

namespace Logging.Data
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonPropertyName("Type 1")]
        public string Type1 { get; set; }

        [JsonPropertyName("Type 2")]
        public string Type2 { get; set; }
        public int Total { get; set; }
        public int HP { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int SpeedAttack { get; set; }
        public int SpeedDefense { get; set; }
        public int Speed { get; set; }
        public int Generation { get; set; }
        public bool Legendary { get; set; }
    }
}
