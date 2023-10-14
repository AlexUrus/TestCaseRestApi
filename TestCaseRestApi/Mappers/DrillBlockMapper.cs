using TestCaseRestApi.Models;
using TestCaseRestApi.Objects;

namespace TestCaseRestApi.Mappers
{
    public class DrillBlockMapper : IMapper<DrillBlockModel,DrillBlock>
    {
        public DrillBlockModel ToModel(DrillBlock obj)
        {
            return new DrillBlockModel(obj);
        }

        public DrillBlock ToObject(DrillBlockModel model)
        {
            return new DrillBlock()
            {
                Id = model.Id,
                Name = model.Name,
                UpdateTime = model.UpdateTime,
            };
        }
    }
}
