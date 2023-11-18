namespace TestCaseRestApi.ModelsDTO
{
    public class DrillBlockModelDTO : AbstractModelDTO
    {
        public string Name { get; set; }
        public DateTime UpdateTime { get; set; }

        public DrillBlockModelDTO(int id, string name, DateTime updatetime)
        {
            Id = id;
            Name = name;
            UpdateTime = updatetime;
        }

        public DrillBlockModelDTO() { }
    }
}
