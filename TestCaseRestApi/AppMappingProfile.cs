using AutoMapper;
using TestCaseRestApi.Models;
using TestCaseRestApi.ModelsDTO;
using TestCaseRestApi.Objects;

namespace TestCaseRestApi
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<DrillBlock, DrillBlockModel>().ReverseMap();
            CreateMap<DrillBlockModel, DrillBlockModelDTO>().ReverseMap();

            CreateMap<Point, PointDTO>().ReverseMap();
            #region DrillBlockPoint
            CreateMap<DrillBlockPoint, DrillBlockPointModel>()
            .ForMember(dest => dest.Point, opt => opt.MapFrom(src => new Point(src.X, src.Y, src.Z)))
            .ForMember(dest => dest.DrillBlockModel, opt => opt.MapFrom(src => src.DrillBlock));

            CreateMap<DrillBlockPointModel, DrillBlockPoint>()
                .ForMember(dest => dest.X, opt => opt.MapFrom(src => src.Point.X))
                .ForMember(dest => dest.Y, opt => opt.MapFrom(src => src.Point.Y))
                .ForMember(dest => dest.Z, opt => opt.MapFrom(src => src.Point.Z))
                .ForMember(dest => dest.DrillBlockId, opt => opt.MapFrom(src => src.DrillBlockModel.Id));

            CreateMap<DrillBlockPointModel, DrillBlockPointModelDTO>()
            .ForMember(dest => dest.PointDTO, opt => opt.MapFrom(src => src.Point))
            .ForMember(dest => dest.DrillBlockModelDTO, opt => opt.MapFrom(src => src.DrillBlockModel))
            .ReverseMap();
            #endregion

            #region Hole
            CreateMap<Hole, HoleModel>()
            .ForMember(dest => dest.DrillBlockModel, opt => opt.MapFrom(src => src.DrillBlock));
            CreateMap<HoleModel, Hole>()
            .ForMember(dest => dest.DrillBlockId, opt => opt.MapFrom(src => src.DrillBlockModel.Id));

            CreateMap<HoleModel, HoleModelDTO>()
            .ForMember(dest => dest.DrillBlockModelDTO, opt => opt.MapFrom(src => src.DrillBlockModel))
            .ReverseMap();
            #endregion

            #region HolePoint
            CreateMap<HolePoint, HolePointModel>()
           .ForMember(dest => dest.Point, opt => opt.MapFrom(src => new Point(src.X, src.Y, src.Z)))
           .ForMember(dest => dest.HoleModel, opt => opt.MapFrom(src => src.Hole));

            CreateMap<HolePointModel, HolePoint>()
                .ForMember(dest => dest.X, opt => opt.MapFrom(src => src.Point.X))
                .ForMember(dest => dest.Y, opt => opt.MapFrom(src => src.Point.Y))
                .ForMember(dest => dest.Z, opt => opt.MapFrom(src => src.Point.Z))
                .ForMember(dest => dest.HoleId, opt => opt.MapFrom(src => src.HoleModel.Id));

            CreateMap<HolePointModel, HolePointModelDTO>()
            .ForMember(dest => dest.PointDTO, opt => opt.MapFrom(src => src.Point))
            .ForMember(dest => dest.HoleModelDTO, opt => opt.MapFrom(src => src.HoleModel))
            .ReverseMap();
            #endregion
        }
    }
}
