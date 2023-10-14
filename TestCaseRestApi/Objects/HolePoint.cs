using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestCaseRestApi.Objects
{
    public class HolePoint : AbstractObject
    {
        [JsonProperty("HoleId")]
        public int HoleId { get; set; }

        [JsonProperty("X")]
        public double X { get; set; }

        [JsonProperty("Y")]
        public double Y { get; set; }

        [JsonProperty("Z")]
        public double Z { get; set; }


        [ForeignKey("HoleId")]
        public Hole Hole { get; set; }
    }
}
