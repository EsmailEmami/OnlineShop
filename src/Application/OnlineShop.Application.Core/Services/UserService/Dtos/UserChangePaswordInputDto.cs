namespace OnlineShop.Application.Core.Services.UserService.Dtos
{
    public class UserChangePaswordInputDto
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string RepeatedNewPassword { get; set; }
    }
}
