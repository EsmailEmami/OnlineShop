using AutoMapper;
using OnlineShop.Application.Core.Services.UserService.Dtos;
using OnlineShop.Domain.Entities.User;

namespace OnlineShop.Application.Core.Services.UserService.MappingProfile
{
    public class UserMap : Profile
    {
        public UserMap()
        {
            CreateMap<User, UserOutputDto>()
                .ForMember(x=> x.FirstName,opt => opt.MapFrom(x=> "fuck you man, yeahhhhh!"));
        }
    }
}
