using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestCaseRestApi.Objects
{
    public class Hole : AbstractObject
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("DrillBlockId")]
        public int DrillBlockId { get; set; }

        [JsonProperty("Depth")]
        public double Depth { get; set; }

        [ForeignKey("DrillBlockId")]
        public DrillBlock DrillBlock { get; set; }

    }
}
