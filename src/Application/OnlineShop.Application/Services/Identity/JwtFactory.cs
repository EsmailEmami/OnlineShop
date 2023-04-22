using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OnlineShop.Application.Core.Authorization;
using OnlineShop.Application.Core.Services.Identity;
using OnlineShop.Application.Core.Services.Identity.Dtos;
using OnlineShop.Common.Extensions;
using OnlineShop.Domain.Entities.User;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Key));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            DateTime ecxpiresAt = DateTime.Now.Add(_jwtOptions.ExpiresAt);
            var tokenOptions = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: claims,
                expires: ecxpiresAt,
                signingCredentials: signinCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);


            return new LoginSuccessResponseDto(user.Id, user.FirstName, user.LastName, user.UserName, user.Email, DateTime.Now.AddDays(30), tokenString);
        }

    }
}
