using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using TestCaseRestApi.Objects;

namespace TestCaseRestApi.Models
{
    public class HoleModel : AbstractModel
    {
        public string Name { get; set; }
        public double Depth { get; set; }
        public DrillBlockModel DrillBlockModel { get; set; }

        [JsonIgnore]
        public List<HolePointModel> HolePoints { get; set; }

        public HoleModel(Hole hole) 
        {
            Id = hole.Id;
            Name = hole.Name;
            Depth = hole.Depth;
            DrillBlockModel = new DrillBlockModel(hole.DrillBlock);
            HolePoints = new List<HolePointModel>();
        }

       public HoleModel() { }
    }
}
