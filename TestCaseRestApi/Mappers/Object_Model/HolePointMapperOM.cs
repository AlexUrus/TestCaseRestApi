using TestCaseRestApi.Models;
using TestCaseRestApi.Objects;

namespace TestCaseRestApi.Mappers.Object_Model
{
    public class HolePointMapperOM : IMapperOM<HolePointModel, HolePoint>
    {
        private readonly HoleMapperOM _holeMapper;
        public HolePointMapperOM()
        {
            _holeMapper = new HoleMapperOM();
        }
        public HolePointModel ToModel(HolePoint obj)
        {
            var holeModel = _holeMapper.ToModel(obj.Hole);
            return new HolePointModel(obj.Id,new Point(obj.X,obj.Y,obj.Z), holeModel);
        }

        public HolePoint ToObject(HolePointModel model)
        {
            return new HolePoint()
            {
                Id = model.Id,
                HoleId = model.HoleModel.Id,
                X = model.Point.X,
                Y = model.Point.Y,
                Z = model.Point.Z
            };
        }
    }
}
