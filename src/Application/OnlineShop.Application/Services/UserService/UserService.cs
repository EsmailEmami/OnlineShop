using OnlineShop.Application.Core.Services.UserService;
using OnlineShop.Application.Core.Services.UserService.Dtos;
using OnlineShop.Application.Mapping;
using OnlineShop.Common.Exceptions;
using OnlineShop.Common.Security;
using OnlineShop.Data.Core;
using OnlineShop.Data.Core.Repositories;
using OnlineShop.Domain.Entities.User;

namespace OnlineShop.Application.Services.UserService
{
    public class UserService : ApplicationService<long, User, UserInputDto, UserUpdateDto, UserOutputDto, UserSPFInputDto>, IUserService
    {
        private readonly IPasswordHasher _passwordHasher;
        public UserService(IMapping mapping, IRepository<User, long> repository, IUnitOfWork unitOfWork, IPasswordHasher passwordHasher) : base(mapping, repository, unitOfWork)
        {
            _passwordHasher = passwordHasher;
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
