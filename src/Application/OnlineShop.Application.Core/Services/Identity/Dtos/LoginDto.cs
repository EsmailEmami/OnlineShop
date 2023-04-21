namespace OnlineShop.Application.Core.Services.Identity.Dtos
{
    public class LoginDto
    {
        public LoginDto()
        {
            
        }

        public LoginDto(string userNameOrEmail, string password)
        {
            UserNameOrEmail = userNameOrEmail;
            Password = password;
        }

        public string UserNameOrEmail { get; set; }
        public string Password { get; set; }
    }

    public class LoginSuccessResponseDto
    {
        public LoginSuccessResponseDto(long id, string firstName, string lastName, string userName,string email, DateTime expiresAt, string token)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Email = email;
            ExpiresAt = expiresAt;
            Token = token;
        }

        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime ExpiresAt { get; set; }
        public string Token { get; set; }
    }
}
