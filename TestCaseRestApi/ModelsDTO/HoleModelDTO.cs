namespace TestCaseRestApi.ModelsDTO
{
    public class HoleModelDTO : AbstractModelDTO
    {
        public string Name { get; set; }
        public double Depth { get; set; }
        public DrillBlockModelDTO DrillBlockModelDTO { get; set; }

        public HoleModelDTO(int id, string name, DrillBlockModelDTO drillBlockModelDTO)
        {
            Id = id;
            Name = name;
            DrillBlockModelDTO = drillBlockModelDTO;
        }
    }
}
