using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestCaseRestApi.Objects
{
    public class DrillBlock : AbstractObject
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("UpdateTime")]
        public DateTime UpdateTime { get; set; }
    }
}
