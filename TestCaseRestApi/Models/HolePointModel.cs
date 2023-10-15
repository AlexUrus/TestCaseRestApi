using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using TestCaseRestApi.Objects;

namespace TestCaseRestApi.Models
{
    public class HolePointModel : AbstractModel
    {
        public Point Point { get; set; }
        public HoleModel HoleModel { get; set; }
        public HolePointModel(int id, Point point, HoleModel holeModel)
        {
            Id = id;
            Point = point;
            HoleModel = holeModel;
        }
    }
}
