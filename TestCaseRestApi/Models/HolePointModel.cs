using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using TestCaseRestApi.Objects;

namespace TestCaseRestApi.Models
{
    public class HolePointModel : AbstractModel
    {
        public Point Point { get; set; }
        public HoleModel HoleModel { get; set; }

        public HolePointModel(HolePoint holePoint) 
        {
            Point = new Point(holePoint.X, holePoint.Y, holePoint.Z);
            HoleModel = new HoleModel(holePoint.Hole);
        }

        public HolePointModel()
        {
            
        }
    }
}
