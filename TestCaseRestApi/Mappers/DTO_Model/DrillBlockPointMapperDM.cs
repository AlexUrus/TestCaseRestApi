using TestCaseRestApi.Models;
using TestCaseRestApi.ModelsDTO;

namespace TestCaseRestApi.Mappers.DTO_Model
{
    public class DrillBlockPointMapperDM : IMapperDM<DrillBlockPointModel, DrillBlockPointModelDTO>
    {
        private DrillBlockMapperDM _drillBlockMapperDM;

        public DrillBlockPointMapperDM()
        {
            _drillBlockMapperDM = new DrillBlockMapperDM();
        }
        public DrillBlockPointModel ToModel(DrillBlockPointModelDTO modelDTO)
        {
            var drillBlockModel = _drillBlockMapperDM.ToModel(modelDTO.DrillBlockModelDTO);

            return new DrillBlockPointModel(
                modelDTO.Id,modelDTO.Sequence, 
              new Point(modelDTO.PointDTO.X, modelDTO.PointDTO.Y, modelDTO.PointDTO.Z), 
                    drillBlockModel);
        }

        public DrillBlockPointModelDTO ToModelDTO(DrillBlockPointModel model)
        {
            var drillBlockModelDTO = _drillBlockMapperDM.ToModelDTO(model.DrillBlockModel);
            return new DrillBlockPointModelDTO(
                model.Id,model.Sequence,
                new PointDTO(model.Point.X,model.Point.Y, model.Point.Z),drillBlockModelDTO);
        }
    }
}
