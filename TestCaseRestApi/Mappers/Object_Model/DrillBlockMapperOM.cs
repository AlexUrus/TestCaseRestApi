using TestCaseRestApi.Models;
using TestCaseRestApi.ModelsDTO;
using TestCaseRestApi.Objects;

namespace TestCaseRestApi.Mappers.Object_Model
{
    public class DrillBlockMapperOM : IMapperOM<DrillBlockModel, DrillBlock>
    {
        public DrillBlockModel ToModel(DrillBlock obj)
        {
            return new DrillBlockModel(obj.Id, obj.Name, obj.UpdateTime);
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
