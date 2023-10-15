using System.ComponentModel.DataAnnotations.Schema;

namespace TestCaseRestApi.Objects
{
    public class DrillBlockPoint : AbstractObject
    {
        public int DrillBlockId { get; set; }
        public int Sequence { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        [ForeignKey("DrillBlockId")]
        public DrillBlock DrillBlock { get; set; }
    }
}
