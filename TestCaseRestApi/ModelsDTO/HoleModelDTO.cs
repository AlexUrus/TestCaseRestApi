using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using TestCaseRestApi.Models;
using TestCaseRestApi.Objects;

namespace TestCaseRestApi.ModelsDTO
{
    public class HoleModelDTO : AbstractModelDTO
    {
        public string Name { get; set; }
        public double Depth { get; set; }
        public DrillBlockModelDTO DrillBlockModelDTO { get; set; }
        public List<HolePointModelDTO> HolePointDTOs { get; set; }

        public HoleModelDTO(int id, string name, DrillBlockModelDTO drillBlockModelDTO, List<HolePointModelDTO> holePointDTOs)
        {
            Id = id;
            Name = name;
            DrillBlockModelDTO = drillBlockModelDTO;
            HolePointDTOs = holePointDTOs;
        }
    }
}
