using TestCaseRestApi.Models;
using TestCaseRestApi.ModelsDTO;

namespace TestCaseRestApi.Mappers.DTO_Model
{
    public class HoleMapperDM : IMapperDM<HoleModel, HoleModelDTO>
    {
        private DrillBlockMapperDM _drillBlockMapperDM;

        public HoleMapperDM()
        {
            _drillBlockMapperDM = new DrillBlockMapperDM();
        }

        public HoleModel ToModel(HoleModelDTO modelDTO)
        {
            var drillblockModel = _drillBlockMapperDM.ToModel(modelDTO.DrillBlockModelDTO);

            return new HoleModel(modelDTO.Id, modelDTO.Name,modelDTO.Depth, drillblockModel);
        }

        public HoleModelDTO ToModelDTO(HoleModel model)
        {
            var drillblockModelDTO = _drillBlockMapperDM.ToModelDTO(model.DrillBlockModel);

            return new HoleModelDTO(model.Id, model.Name, drillblockModelDTO);
        }
    }
}
