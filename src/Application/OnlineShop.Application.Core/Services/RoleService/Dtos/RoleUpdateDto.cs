using OnlineShop.Domain.Entities.Permission;

namespace OnlineShop.Application.Core.Services.RoleService.Dtos
{
    public class RoleUpdateDto
    {
        public string Name { get; set; }
        public RoleType RoleType { get; set; }

        public string[] PermissionNames { get; set; }
    }
}
