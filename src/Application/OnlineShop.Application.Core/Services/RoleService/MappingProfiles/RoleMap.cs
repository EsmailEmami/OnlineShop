using AutoMapper;
using OnlineShop.Application.Core.Services.RoleService.Dtos;
using OnlineShop.Domain.Entities.Permission;

namespace OnlineShop.Application.Core.Services.RoleService.MappingProfiles
{
    public class RoleMap : Profile
    {
        public RoleMap()
        {
            CreateMap<Role, RoleOutputDto>()
                .ForMember(x => x.PermissionNames, opt => opt.Ignore());
        }
    }
}
