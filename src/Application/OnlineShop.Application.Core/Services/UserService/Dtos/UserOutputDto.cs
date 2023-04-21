using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Core.Services.UserService.Dtos
{
    public class UserOutputDto
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string UserAvatar { get; set; }
        public string PhoneNumber { get; set; }
        public string InviteCode { get; set; }
        public int InviteCount { get; set; }
        public int Score { get; set; }
        public string NationalCode { get; set; }
        public decimal AccountBalance { get; set; }
        public DateTime RegisterDate { get; set; }
        public string Password { get; set; }
        public bool IsBlocked { get; set; }
    }
}
