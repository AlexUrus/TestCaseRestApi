using TestCaseRestApi.Models;
using TestCaseRestApi.ModelsDTO;

namespace TestCaseRestApi.Mappers.DTO_Model
{
    public class HoleMapperDM : IMapperDM<HoleModel, HoleModelDTO>
    {
        private DrillBlockMapperDM _drillBlockMapperDM;
        private HolePointMapperDM _holePointMapperDM;

        public HoleMapperDM()
        {
            _drillBlockMapperDM = new DrillBlockMapperDM();
            _holePointMapperDM = new HolePointMapperDM();
        }

        public HoleModel ToModel(HoleModelDTO modelDTO)
        {
            var holePointModels = new List<HolePointModel>();
            foreach (var item in modelDTO.HolePointDTOs)
            {
                holePointModels.Add(_holePointMapperDM.ToModel(item));
            }

            var drillblockModel = _drillBlockMapperDM.ToModel(modelDTO.DrillBlockModelDTO);

            return new HoleModel(modelDTO.Id, modelDTO.Name,modelDTO.Depth, drillblockModel, holePointModels);
        }

        public HoleModelDTO ToModelDTO(HoleModel model)
        {
            var holePointModelDTOs = new List<HolePointModelDTO>();
            foreach (var item in model.HolePoints)
            {
                holePointModelDTOs.Add(_holePointMapperDM.ToModelDTO(item));
            }

            var drillblockModelDTO = _drillBlockMapperDM.ToModelDTO(model.DrillBlockModel);

            return new HoleModelDTO(model.Id, model.Name, drillblockModelDTO, holePointModelDTOs);
        }
    }
}
