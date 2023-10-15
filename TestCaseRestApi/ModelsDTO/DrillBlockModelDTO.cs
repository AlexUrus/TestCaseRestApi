using Newtonsoft.Json;
using TestCaseRestApi.Models;
using TestCaseRestApi.ModelsDTO;

namespace TestCaseRestApi.ModelsDTO
{
    public class DrillBlockModelDTO : AbstractModelDTO
    {
        public string Name { get; set; }
        public DateTime UpdateTime { get; set; }
        public List<HoleModelDTO> HoleModelDTOs { get; set; }
        public List<DrillBlockPointModelDTO> DrillBlockPointModelDTOs { get; set; }

        public DrillBlockModelDTO(int id, string name, DateTime updatetime, List<HoleModelDTO> holeModelIds = null, List<DrillBlockPointModelDTO> drillBlockPointModelIds = null)
        {
            Id = id;
            Name = name;
            UpdateTime = updatetime;

            HoleModelDTOs = holeModelIds ?? new List<HoleModelDTO>();
            DrillBlockPointModelDTOs = drillBlockPointModelIds ?? new List<DrillBlockPointModelDTO>();
        }
    }
}
