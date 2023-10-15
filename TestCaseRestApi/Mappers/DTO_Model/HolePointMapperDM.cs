using TestCaseRestApi.Models;
using TestCaseRestApi.ModelsDTO;

namespace TestCaseRestApi.Mappers.DTO_Model
{
    public class HolePointMapperDM : IMapperDM<HolePointModel, HolePointModelDTO>
    {
        private HoleMapperDM _holeMapperDM;

        public HolePointMapperDM()
        {
            _holeMapperDM = new HoleMapperDM();
        }

        public HolePointModel ToModel(HolePointModelDTO modelDTO)
        {
            var holeModel = _holeMapperDM.ToModel(modelDTO.HoleModelDTO);

            return new HolePointModel(modelDTO.Id, 
                new Point(modelDTO.PointDTO.X,modelDTO.PointDTO.Y, modelDTO.PointDTO.Z), holeModel);
        }

        public HolePointModelDTO ToModelDTO(HolePointModel model)
        {
            var holeModelDTO = _holeMapperDM.ToModelDTO(model.HoleModel);

            return new HolePointModelDTO(model.Id,
                new PointDTO(model.Point.X, model.Point.Y, model.Point.Z), holeModelDTO);
        }
    }
}
