using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Core.Services.UserService;
using OnlineShop.Application.Core.Services.UserService.Dtos;
using OnlineShop.Domain.Entities.User;

namespace OnlineShop.Api.Controllers.Web
{
    public class UserController : BaseApiController<long, User, UserInputDto, UserUpdateDto, UserOutputDto, UserSPFInputDto>
    {
        private readonly IUserService _userService;

        public UserController(IUserService service) : base(service)
        {
            _userService = service;
        }

        [HttpPost]
        [Route("[action]/{id}")]
        public async Task<IActionResult> ChangePassword([FromRoute] long id, [FromBody] UserChangePaswordInputDto model)
        {
            await _userService.ChangePassword(id, model);
            return OkResult(model);
        }
    }
}

