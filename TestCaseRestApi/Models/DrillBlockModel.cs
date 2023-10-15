using Newtonsoft.Json;
using TestCaseRestApi.ModelsDTO;
using TestCaseRestApi.Objects;

namespace TestCaseRestApi.Models
{
    public class DrillBlockModel : AbstractModel
    {
        public string Name { get; set; }
        public DateTime UpdateTime { get; set; }
        public List<HoleModel> HoleModels { get; set; }
        public List<DrillBlockPointModel> DrillBlockPointModels { get; set; }

        public DrillBlockModel(DrillBlock drillBlock)
        {
            Id = drillBlock.Id;
            Name = drillBlock.Name;
            UpdateTime = drillBlock.UpdateTime;
            HoleModels = new List<HoleModel>();
            DrillBlockPointModels = new List<DrillBlockPointModel>();
        }

        public DrillBlockModel(int id, string name, DateTime updatetime, List<HoleModel> holeModels = null, List<DrillBlockPointModel> drillBlockPointModels = null)
        {
            Id = id;
            Name = name;
            UpdateTime = updatetime;

            HoleModels = holeModels ?? new List<HoleModel>();
            DrillBlockPointModels = drillBlockPointModels ?? new List<DrillBlockPointModel>();
        }
    }
}
