using TestCaseRestApi.Models;
using TestCaseRestApi.Objects;

namespace TestCaseRestApi.Mappers.Object_Model
{
    public class HoleMapperOM : IMapperOM<HoleModel, Hole>
    {
        public HoleModel ToModel(Hole obj)
        {
            return new HoleModel(obj);
        }

        public Hole ToObject(HoleModel model)
        {
            return new Hole()
            {
                Id = model.Id,
                Name = model.Name,
                Depth = model.Depth,
                DrillBlockId = model.DrillBlockModel.Id,
            };
        }
    }
}
