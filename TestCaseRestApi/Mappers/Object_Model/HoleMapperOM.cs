using TestCaseRestApi.Models;
using TestCaseRestApi.Objects;

namespace TestCaseRestApi.Mappers.Object_Model
{
    public class HoleMapperOM : IMapperOM<HoleModel, Hole>
    {
        private readonly DrillBlockMapperOM _drillBlockMapper;
        public HoleMapperOM()
        {
            _drillBlockMapper = new DrillBlockMapperOM();
        }
        public HoleModel ToModel(Hole obj)
        {
            var drillBlockModel = _drillBlockMapper.ToModel(obj.DrillBlock);
            return new HoleModel(obj.Id, obj.Name, obj.Depth, drillBlockModel);
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
