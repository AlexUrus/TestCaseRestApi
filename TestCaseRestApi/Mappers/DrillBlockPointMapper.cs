using TestCaseRestApi.Models;
using TestCaseRestApi.Objects;

namespace TestCaseRestApi.Mappers
{
    public class DrillBlockPointMapper : IMapper<DrillBlockPointModel, DrillBlockPoint>
    {
        public DrillBlockPointModel ToModel(DrillBlockPoint obj)
        {
            return new DrillBlockPointModel(obj);
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
