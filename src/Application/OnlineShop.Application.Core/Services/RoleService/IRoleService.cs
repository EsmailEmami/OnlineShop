using OnlineShop.Application.Core.Services.RoleService.Dtos;
using OnlineShop.Domain.Entities.Permission;

namespace OnlineShop.Application.Core.Services.RoleService
{
    public interface IRoleService : IApplicationService<int, Role, RoleInputDto, RoleUpdateDto, RoleOutputDto>
    {

    }
}
