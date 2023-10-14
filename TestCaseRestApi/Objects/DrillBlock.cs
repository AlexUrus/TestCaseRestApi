using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestCaseRestApi.Objects
{
    public class DrillBlock : AbstractObject
    {
        public string Name { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
