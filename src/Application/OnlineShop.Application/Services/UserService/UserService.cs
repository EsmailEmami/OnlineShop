using Microsoft.AspNetCore.DataProtection;
using OnlineShop.Application.Core.Services.PermissionService;
using OnlineShop.Application.Core.Services.UserService;
using OnlineShop.Application.Core.Services.UserService.Dtos;
using OnlineShop.Application.Mapping;
using OnlineShop.Common.Exceptions;
using OnlineShop.Common.Security;
using OnlineShop.Data.Core;
using OnlineShop.Data.Core.Repositories;
using OnlineShop.Domain.Entities.Permission;
using OnlineShop.Domain.Entities.User;
using System.Xml.Linq;

namespace OnlineShop.Application.Services.UserService
{
    public class UserService : ApplicationService<long, User, UserInputDto, UserUpdateDto, UserOutputDto, UserSPFInputDto>, IUserService
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IDataProtectionProvider _rootProvider;
        private readonly IPermissionService _permissionService;
        public UserService(IMapping mapping, IRepository<User, long> repository, IUnitOfWork unitOfWork, IPasswordHasher passwordHasher, IDataProtectionProvider rootProvider, IPermissionService permissionService) : base(mapping, repository, unitOfWork)
        {
            _passwordHasher = passwordHasher;
            _rootProvider = rootProvider;
            _permissionService = permissionService;
        }

        public async Task ChangePassword(long userId, UserChangePaswordInputDto model)
        {
            var user = _repository.FirstOrDefault(userId);
            if (user == null)
            {
                throw new BadRequestException("مشکلی پیش آمده است!");
            }

            if (!model.NewPassword.Equals(model.RepeatedNewPassword))
            {
                throw new BadRequestException("لطفا رمز عبور خود را به درستی وارد کنید");
            }

            if (!_passwordHasher.Check(user.Password, model.CurrentPassword)) 
            {
                throw new BadRequestException("لطفا رمز عبور خود را به درستی وارد کنید");
            }

            var newPass = _passwordHasher.Hash(model.NewPassword);

            user.Password = newPass;

            await _repository.UpdateAsync(user);
            _unitOfWork.SaveAllChanges();
        }

        public async Task<User> CreateUserAsync(User user)
        {
            await _repository.InsertAsync(user);
            _unitOfWork.SaveAllChanges();

            return user;
        }

        public IList<string> GetUserPeymissions(long userId)
        {
            var user = _repository.Get(userId);
            var securityTamp = user.Role.SecurityStamp;

            string purpose = "OnlineShop.Application.Services.RoleService";
            IDataProtector protector = _rootProvider.CreateProtector(purpose, securityTamp);
            
            List<string> permissions = new List<string>();
            try
            {
                permissions = _permissionService.GetUserPermissionsAsList(XElement.Parse(protector.Unprotect(user.Role.Permissions))).ToList();
            }
            catch
            {
                //Ignored
            }

            return permissions;
        }

        public User Login(string userNameOrEmail, string password)
        {
            var user = _repository.FirstOrDefault(c=> c.UserName == userNameOrEmail || c.Email == userNameOrEmail);
            if (user == null)
            {
                throw new NotFoundException("کاربری با مشخصات وارد شده یافت نشد");
            }

            if (!_passwordHasher.Check(user.Password ,password))
            {
                throw new NotFoundException("کاربری با مشخصات وارد شده یافت نشد");
            }

            return user;
        }
    }
}
