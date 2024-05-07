using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Logging.Domain
{
    public class Pokemon
    {
        [JsonProperty("#")]
        public int  Id { get; set; }
    public string Name { get; set; }

    [JsonProperty("Type 1")]
    public string Type1 { get; set; }

    [JsonProperty("Type 2")]
    public string Type2 { get; set; }
    public int Total { get; set; }
    public int HP { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }

    [JsonProperty("Sp. Atk")]
    public int SpAtk { get; set; }

    [JsonProperty("Sp. Def")]
    public int SpDef { get; set; }
    public int Speed { get; set; }
    public int Generation { get; set; }
    public string Legendary { get; set; }
}
}
