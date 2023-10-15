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

        public DrillBlockModel(int id, string name, DateTime updatetime)
        {
            Id = id;
            Name = name;
            UpdateTime = updatetime;
        }
    }
}
