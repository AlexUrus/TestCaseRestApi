using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using TestCaseRestApi.Objects;

namespace TestCaseRestApi.Models
{
    public class HoleModel : AbstractModel
    {
        public string Name { get; set; }
        public double Depth { get; set; }
        public DrillBlockModel DrillBlockModel { get; set; }

        public HoleModel(int id, string name, double depth, DrillBlockModel drillBlockModel) 
        {
            Id = id;
            Name = name;
            Depth = depth;
            DrillBlockModel = drillBlockModel;
        }
    }
}
