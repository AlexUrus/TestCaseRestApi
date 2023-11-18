using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestCaseRestApi.Objects
{
    public class HolePoint : AbstractObject
    {
        public int HoleId { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        [ForeignKey("HoleId")]
        public Hole Hole { get; set; }

        public HolePoint()
        {
            
        }
    }
}
