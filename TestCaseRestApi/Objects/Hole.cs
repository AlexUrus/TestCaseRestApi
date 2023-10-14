using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestCaseRestApi.Objects
{
    public class Hole : AbstractObject
    {
        public string Name { get; set; }
        public int DrillBlockId { get; set; }
        public double Depth { get; set; }
        public DrillBlock DrillBlock { get; set; }
    }
}
