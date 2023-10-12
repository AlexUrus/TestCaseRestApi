using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestCaseRestApi.Objects
{
    public class Hole
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("DrillBlock")]
        public DrillBlock DrillBlock { get; set; }

        [JsonProperty("Depth")]
        public double Depth { get; set; }

        [JsonProperty("HolePoints")]
        public List<HolePoint> HolePoints { get; set; }
    }
}
