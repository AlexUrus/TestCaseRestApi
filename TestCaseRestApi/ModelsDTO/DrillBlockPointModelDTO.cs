
namespace TestCaseRestApi.ModelsDTO
{
    public class DrillBlockPointModelDTO : AbstractModelDTO
    {
        public int Sequence { get; set; }
        public PointDTO PointDTO { get; set; }
        public DrillBlockModelDTO DrillBlockModelDTO { get; set; }

        public DrillBlockPointModelDTO(int id, int sequence, PointDTO pointDTO, DrillBlockModelDTO drillBlockModelDTO)
        {
            Id = id;
            Sequence = sequence;
            PointDTO = pointDTO;
            DrillBlockModelDTO = drillBlockModelDTO;
        }
    }
}
