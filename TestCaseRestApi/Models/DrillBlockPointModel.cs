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

        public DrillBlockPointModel(int id, int sequence, Point point, DrillBlockModel drillBlockModel)
        {
            Id = id;
            Sequence = sequence;
            Point = point;
            DrillBlockModel = drillBlockModel;
        }

        public DrillBlockPointModel()
        {
            
        }
    }
}
