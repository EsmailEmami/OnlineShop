using OnlineShop.Application.Core.Services.UserService;
using OnlineShop.Application.Core.Services.UserService.Dtos;
using OnlineShop.Application.Mapping;
using OnlineShop.Data.Core;
using OnlineShop.Data.Core.Repositories;
using OnlineShop.Domain.Entities.User;

namespace OnlineShop.Application.Services.UserService
{
    public class UserService : ApplicationService<long, User, UserInputDto, UserUpdateDto, UserOutputDto, UserSPFInputDto>, IUserService
    {
        public UserService(IMapping mapping, IRepository<User, long> repository, IUnitOfWork unitOfWork) : base(mapping, repository, unitOfWork)
        {
        }
    }
}
