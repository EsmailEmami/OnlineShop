using AutoMapper;
using OnlineShop.Application.Core.Services.CityService.Dtos;
using OnlineShop.Domain.Entities.User;

namespace OnlineShop.Application.Core.Services.CityService.MappingProfiles
{
    public class CityMap : Profile
    {
        public CityMap()
        {
            CreateMap<CityInputDto, City>();
            CreateMap<CityUpdateDto, City>();
            CreateMap<City, CityOutputDto>()
                .ForMember(x => x.StateName, opt => opt.MapFrom(x => x.State.Name));
        }
    }
}
