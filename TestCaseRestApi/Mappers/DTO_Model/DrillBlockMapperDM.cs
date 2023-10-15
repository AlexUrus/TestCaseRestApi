using TestCaseRestApi.Models;
using TestCaseRestApi.ModelsDTO;

namespace TestCaseRestApi.Mappers.DTO_Model
{
    public class DrillBlockMapperDM : IMapperDM<DrillBlockModel, DrillBlockModelDTO>
    {
        private HoleMapperDM _holeMapperDM;
        private DrillBlockPointMapperDM _drillBlockPointMapperDM;

        public DrillBlockMapperDM()
        {
            _holeMapperDM = new HoleMapperDM();
            _drillBlockPointMapperDM = new DrillBlockPointMapperDM();
        }

        public DrillBlockModel ToModel(DrillBlockModelDTO modelDTO)
        {
            var drillBlockPointModels = new List<DrillBlockPointModel>();
            foreach (var item in modelDTO.DrillBlockPointModelDTOs)
            {
                drillBlockPointModels.Add(_drillBlockPointMapperDM.ToModel(item));
            }

            var holeModels = new List<HoleModel>();
            foreach (var item in modelDTO.HoleModelDTOs)
            {
                holeModels.Add(_holeMapperDM.ToModel(item));
            }

            return new DrillBlockModel(modelDTO.Id,modelDTO.Name,modelDTO.UpdateTime,holeModels,drillBlockPointModels);
        }

        public DrillBlockModelDTO ToModelDTO(DrillBlockModel model)
        {
            var drillBlockPointModelDTOs = new List<DrillBlockPointModelDTO>();
            foreach (var item in model.DrillBlockPointModels)
            {
                drillBlockPointModelDTOs.Add(_drillBlockPointMapperDM.ToModelDTO(item));
            }

            var holeModelDTOs = new List<HoleModelDTO>();
            foreach (var item in model.HoleModels)
            {
                holeModelDTOs.Add(_holeMapperDM.ToModelDTO(item));
            }

            return new DrillBlockModelDTO(model.Id, model.Name, model.UpdateTime, holeModelDTOs, drillBlockPointModelDTOs);
        }
    }
}
