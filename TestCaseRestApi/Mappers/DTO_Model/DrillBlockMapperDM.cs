using TestCaseRestApi.Models;
using TestCaseRestApi.ModelsDTO;

namespace TestCaseRestApi.Mappers.DTO_Model
{
    public class DrillBlockMapperDM : IMapperDM<DrillBlockModel, DrillBlockModelDTO>
    {
        public DrillBlockModel ToModel(DrillBlockModelDTO modelDTO)
        {
            return new DrillBlockModel(modelDTO.Id,modelDTO.Name,modelDTO.UpdateTime);
        }

        public DrillBlockModelDTO ToModelDTO(DrillBlockModel model)
        {
            return new DrillBlockModelDTO(model.Id, model.Name, model.UpdateTime);
        }
    }
}
