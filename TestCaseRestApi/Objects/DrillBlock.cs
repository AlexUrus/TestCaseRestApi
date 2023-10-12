using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestCaseRestApi.Objects
{
    public class DrillBlock
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("UpdateTime")]
        public DateTime UpdateTime { get; set; }

        [JsonProperty("Holes")]
        public List<Hole> Holes { get; set; }

        [JsonProperty("DrillBlockPoints")]
        public List<DrillBlockPoint> DrillBlockPoints { get; set; }
    }
}
