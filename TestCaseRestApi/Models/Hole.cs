namespace TestCaseRestApi.Models
{
    public class Hole
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DrillBlock DrillBlock { get; set; }
        public double Depth { get; set; }
    }
}
