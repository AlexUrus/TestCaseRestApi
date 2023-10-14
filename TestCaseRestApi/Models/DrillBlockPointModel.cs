using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using TestCaseRestApi.Objects;

namespace TestCaseRestApi.Models
{
    public class DrillBlockPointModel : AbstractModel
    {
        public int Sequence { get; set; }
        public Point Point { get; set; }
        public DrillBlockModel DrillBlockModel { get; set; }

        public DrillBlockPointModel(DrillBlockPoint drillBlockPoint) 
        {
            Id = drillBlockPoint.Id;
            Sequence = drillBlockPoint.Sequence;
            Point = new Point(drillBlockPoint.X, drillBlockPoint.Y, drillBlockPoint.Z);
            DrillBlockModel = new DrillBlockModel(drillBlockPoint.DrillBlock);
        }

        public DrillBlockPointModel() { }

    }
}
