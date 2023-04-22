using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Core.Services.Identity;
using OnlineShop.Application.Core.Services.Identity.Dtos;
using OnlineShop.Application.Core.Services.UserService;
using OnlineShop.Common.Exceptions;
using OnlineShop.Common.Security;
using OnlineShop.Data.Core.Repositories;
using OnlineShop.Domain.Entities.Permission;
using OnlineShop.Domain.Entities.User;

namespace OnlineShop.Api.Controllers.Web
{
    public class AccountController : BaseApiController
    {
        private readonly IJwtFactory _jwtFactory;
        private readonly IUserService _userService;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IRepository<Role,int> _roleRepository;

        public AccountController(IUserService userService, IJwtFactory jwtFactory, IPasswordHasher passwordHasher, IRepository<Role, int> roleRepository)
        {
            _userService = userService;
            _jwtFactory = jwtFactory;
            _passwordHasher = passwordHasher;
            _roleRepository = roleRepository;
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Login([FromBody] LoginDto model)
        {
            User user = _userService.Login(model.UserNameOrEmail, model.Password);

            return OkResult(_jwtFactory.GenerateJwtToken(user));
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        {
            if (!model.Password.Equals(model.RepeatedPassword))
            {
                throw new BadRequestException("لطفا پسورد خود را درست وارد کنید");
            }

            var hashedPassword = _passwordHasher.Hash(model.Password);
            var role = _roleRepository.FirstOrDefault(c => c.RoleType == RoleType.Admin);

            var user = new User(model.FirstName, model.UserName, hashedPassword, model.LastName,role.Id);
            await _userService.CreateUserAsync(user);

            return Login(new LoginDto(user.UserName, model.Password));
        }
    }
}
