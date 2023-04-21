using OnlineShop.Application.Core.Services.Identity.Dtos;
using OnlineShop.Domain.Entities.User;
using System.Security.Claims;

namespace OnlineShop.Application.Core.Services.Identity
{
    public interface IJwtFactory
    {
        LoginSuccessResponseDto GenerateJwtToken(User user);
    }
}
