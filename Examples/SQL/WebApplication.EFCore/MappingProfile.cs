using AutoMapper;
using Database.EFCore.Entities;

namespace WebApplication.EFCore
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<WeatherEntity, WeatherForecast>()
                .ForMember(
                    dst => dst.Summary, 
                    opt => opt.MapFrom(src => src.Summary.Code))
                .ForMember(
                    dst => dst.TemperatureC,
                    opt => opt.MapFrom(src => src.Temperature));
        }
    }
}