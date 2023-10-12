using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestCaseRestApi.Objects
{
    public class HolePoint
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Hole")]
        public Hole Hole { get; set; }

        [JsonProperty("X")]
        public double X { get; set; }

        [JsonProperty("Y")]
        public double Y { get; set; }

        [JsonProperty("Z")]
        public double Z { get; set; }
    }
}
