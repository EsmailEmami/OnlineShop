using Microsoft.AspNetCore.Http;
using OnlineShop.Common.Extensions;
using OnlineShop.Domain.Identity;
using System.Security.Claims;

namespace OnlineShop.Infrastructure.Authorization
{
    public class AspNetUser : IUser
    {
        private readonly IHttpContextAccessor _accessor;
        public AspNetUser(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public long UserId => _accessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier).Parse<long>() ?? 0;

        public bool IsAuthenticated => _accessor.HttpContext!.User.Identity!.IsAuthenticated;
    }
}
