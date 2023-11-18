using System.ComponentModel.DataAnnotations.Schema;

namespace TestCaseRestApi.Objects
{
    public class Hole : AbstractObject
    {
        public string Name { get; set; }
        public int DrillBlockId { get; set; }
        public double Depth { get; set; }

        [ForeignKey("DrillBlockId")]
        public DrillBlock DrillBlock { get; set; }

        public Hole()
        {
            
        }
    }
}
