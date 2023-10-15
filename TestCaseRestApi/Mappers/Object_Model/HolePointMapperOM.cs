using TestCaseRestApi.Models;
using TestCaseRestApi.Objects;

namespace TestCaseRestApi.Mappers.Object_Model
{
    public class HolePointMapperOM : IMapperOM<HolePointModel, HolePoint>
    {
        public HolePointModel ToModel(HolePoint obj)
        {
            return new HolePointModel(obj);
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
