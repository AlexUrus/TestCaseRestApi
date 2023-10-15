using TestCaseRestApi.Models;
using TestCaseRestApi.Objects;

namespace TestCaseRestApi.Mappers.Object_Model
{
    public class DrillBlockPointMapperOM : IMapperOM<DrillBlockPointModel, DrillBlockPoint>
    {
        private readonly DrillBlockMapperOM _drillBlockMapper;
        public DrillBlockPointMapperOM()
        {
            _drillBlockMapper = new DrillBlockMapperOM(); 
        }

        public DrillBlockPointModel ToModel(DrillBlockPoint obj)
        {
            var drillBlockModel = _drillBlockMapper.ToModel(obj.DrillBlock);
            return new DrillBlockPointModel(obj.DrillBlockId, obj.Sequence, new Point(obj.X,obj.Y,obj.Z),drillBlockModel);
        }

        public DrillBlockPoint ToObject(DrillBlockPointModel model)
        {
            return new DrillBlockPoint()
            {
                Id = model.Id,
                DrillBlockId = model.DrillBlockModel.Id,
                Sequence = model.Sequence,
                X = model.Point.X,
                Y = model.Point.Y,
                Z = model.Point.Z,
            };
        }
    }
}
