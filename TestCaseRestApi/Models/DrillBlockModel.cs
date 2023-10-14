using Newtonsoft.Json;
using TestCaseRestApi.Objects;

namespace TestCaseRestApi.Models
{
    public class DrillBlockModel : AbstractModel
    {
        public string Name { get; set; }
        public DateTime UpdateTime { get; set; }

        [JsonIgnore]
        public List<Hole> Holes { get; set; }
        [JsonIgnore]
        public List<DrillBlockPoint> DrillBlockPoints { get; set; }

        public DrillBlockModel(DrillBlock drillBlock)
        {
            Id = drillBlock.Id;
            Name = drillBlock.Name;
            UpdateTime = drillBlock.UpdateTime;
            Holes = new List<Hole>();
            DrillBlockPoints = new List<DrillBlockPoint>();
        }

        public DrillBlockModel() { }
    }
}
