using OnlineShop.Common.Dtos;

namespace OnlineShop.Application.Core.Services.UserService.Dtos
{
    public class UserSPFInputDto : SPFInputDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
    }
}
