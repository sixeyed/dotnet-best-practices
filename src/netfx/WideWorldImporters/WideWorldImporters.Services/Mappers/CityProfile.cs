using AutoMapper;
using data = WideWorldImporters.Data;
using entities = WideWorldImporters.Services.Entities;

namespace WideWorldImporters.Services.Mappers
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<data.City, entities.City>()
                .ForMember(dest => dest.Population, opt => opt.MapFrom(src => src.LatestRecordedPopulation))
                .ForMember(dest => dest.StateProvinceName, opt => opt.MapFrom(src => src.StateProvince.StateProvinceName));
        }
    }
}