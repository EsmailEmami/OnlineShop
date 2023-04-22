using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Core.Services.RoleService;
using OnlineShop.Application.Core.Services.RoleService.Dtos;
using OnlineShop.Application.Security.Permissions;
using OnlineShop.Domain.Entities.Permission;

namespace OnlineShop.Api.Controllers.Web
{
    public class RoleController : BaseApiController<int, Role, RoleInputDto, RoleUpdateDto, RoleOutputDto>
    {
        public RoleController(IRoleService service) : base(service)
        {
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult Permissions()
        {
            return OkResult(AssignableToRolePermissions.GetAsSelectListItems());
        }
    }
}
