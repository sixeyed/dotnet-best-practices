using AutoMapper;
using data = WorldWideImporters.Data;
using model = WorldWideImporters.Model;

namespace WorldWideImporters.Mapping
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<data.City, model.City>()
                .ForMember(dest => dest.Population, opt => opt.MapFrom(src => src.LatestRecordedPopulation))
                .ForMember(dest => dest.StateProvinceName, opt => opt.MapFrom(src => src.StateProvince.StateProvinceName));
        }
    }
}
