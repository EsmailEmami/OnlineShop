using OnlineShop.Application.Core.Services.CityService;
using OnlineShop.Application.Core.Services.CityService.Dtos;
using OnlineShop.Application.Security.Attributes;
using OnlineShop.Application.Security.Permissions;
using OnlineShop.Domain.Entities.User;

namespace OnlineShop.Api.Controllers.Web
{
    [Permission(AssignableToRolePermissions.UserAccess)]
    public class CityController : BaseApiController<int, City, CityInputDto, CityUpdateDto, CityOutputDto>
    {
        public CityController(ICityService service) : base(service)
        {
        }
    }
}
