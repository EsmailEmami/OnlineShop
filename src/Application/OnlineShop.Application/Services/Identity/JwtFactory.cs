using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OnlineShop.Application.Core.Authorization;
using OnlineShop.Application.Core.Services.Identity;
using OnlineShop.Application.Core.Services.Identity.Dtos;
using OnlineShop.Common.Extensions;
using OnlineShop.Domain.Entities.User;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace OnlineShop.Application.Services.Identity
{
    public class JwtFactory : IJwtFactory
    {
        private readonly IdentityOptions _jwtOptions;

        public JwtFactory(IOptions<IdentityOptions> jwtOptions)
        {
            _jwtOptions = jwtOptions.Value;
        }

        public LoginSuccessResponseDto GenerateJwtToken(User user)
        {
            var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.GivenName, string.Concat(user.FirstName, " ", user.LastName)),
                    new Claim(ClaimTypes.Name, user.UserName),
                };

            if (user.Email.HasValue())
            {
                claims.Add(new Claim(ClaimTypes.Email, user.Email));
            }

            var identity = new ClaimsIdentity(claims);

            var tokenHandler = new JwtSecurityTokenHandler();
            DateTime expiresAt = DateTime.Now.Add(_jwtOptions.TokenExpires);
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _jwtOptions.ClaimsIssuer,
                Audience = _jwtOptions.Audience,
                Subject = identity,
                NotBefore = DateTime.UtcNow,
                Expires = expiresAt,
                SigningCredentials = _jwtOptions.Credentials,
            });

            var strToken = tokenHandler.WriteToken(token);

            return new LoginSuccessResponseDto(user.Id, user.FirstName, user.LastName, user.UserName, user.Email, expiresAt, strToken);
        }

    }
}
