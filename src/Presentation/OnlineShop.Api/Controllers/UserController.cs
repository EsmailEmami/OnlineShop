using OnlineShop.Application.Core.Services.UserService;
using OnlineShop.Application.Core.Services.UserService.Dtos;
using OnlineShop.Domain.Entities.User;

namespace OnlineShop.Api.Controllers
{
    public class UserController : BaseApiController<long, User, UserInputDto, UserUpdateDto, UserOutputDto, UserSPFInputDto>
    {
        public UserController(IUserService service) : base(service)
        {
          
        }
    }
}
