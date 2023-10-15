using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using TestCaseRestApi.Objects;

namespace TestCaseRestApi.ModelsDTO
{
    public class HolePointModelDTO : AbstractModelDTO
    {
        public PointDTO PointDTO { get; set; }
        public HoleModelDTO HoleModelDTO { get; set; }

        public HolePointModelDTO(int id, PointDTO pointDTO, HoleModelDTO holeModelDTO)
        {
            Id = id;
            PointDTO = pointDTO;
            HoleModelDTO = holeModelDTO;
        }

    }
}
