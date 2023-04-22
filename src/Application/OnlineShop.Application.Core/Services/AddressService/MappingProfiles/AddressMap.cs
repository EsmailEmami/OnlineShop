using AutoMapper;
using OnlineShop.Application.Core.Services.AddressService.Dtos;
using OnlineShop.Application.Core.Services.CartItemService.Dtos;
using OnlineShop.Domain.Entities.Cart;
using OnlineShop.Domain.Entities.User;

namespace OnlineShop.Application.Core.Services.AddressService.MappingProfiles
{
    public class AddressMap : Profile
    {
        public AddressMap()
        {
            CreateMap<AddressInputDto, Address>();
            CreateMap<AddressUpdateDto, Address>();
            CreateMap<Address, AddressOutputDto>()
                 .ForMember(x => x.CityName, opt => opt.MapFrom(x => x.City.Name))
                 .ForMember(x => x.StateId, opt => opt.MapFrom(x => x.City.StateId))
                 .ForMember(x => x.StateName, opt => opt.MapFrom(x => x.City.State.Name));
        }
    }
}
