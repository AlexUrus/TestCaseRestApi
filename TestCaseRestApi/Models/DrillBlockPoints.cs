namespace TestCaseRestApi.Models
{
    public class DrillBlockPoints
    {
        public int Id { get; set; }
        public DrillBlock DrillBlock { get; set; }
        public string Sequence { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
    }
}
