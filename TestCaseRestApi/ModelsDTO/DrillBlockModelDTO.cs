using Newtonsoft.Json;
using TestCaseRestApi.Models;
using TestCaseRestApi.ModelsDTO;

namespace TestCaseRestApi.ModelsDTO
{
    public class DrillBlockModelDTO : AbstractModelDTO
    {
        public string Name { get; set; }
        public DateTime UpdateTime { get; set; }

        public DrillBlockModelDTO(int id, string name, DateTime updatetime)
        {
            Id = id;
            Name = name;
            UpdateTime = updatetime;
        }
    }
}
