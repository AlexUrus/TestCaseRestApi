using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestCaseRestApi.Objects
{
    public class DrillBlockPoint : AbstractObject
    {
        [JsonProperty("DrillBlockId")]
        public int DrillBlockId { get; set; }

        [JsonProperty("Sequence")]
        public int Sequence { get; set; }

        [JsonProperty("X")]
        public double X { get; set; }

        [JsonProperty("Y")]
        public double Y { get; set; }

        [JsonProperty("Z")]
        public double Z { get; set; }


        [ForeignKey("DrillBlockId")]
        public DrillBlock DrillBlock { get; set; }
    }
}
