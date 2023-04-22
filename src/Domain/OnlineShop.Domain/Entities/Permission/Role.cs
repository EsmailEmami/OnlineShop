using OnlineShop.Domain.Core;
using OnlineShop.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Entities.Permission
{
    public class Role : Entity<int>
    {
        public string Name { get; set; }
        public RoleType RoleType { get; set; }

        public virtual string Permissions { get; set; }
        public string SecurityStamp { get; set; }

        public virtual ICollection<User.User> Users { get; set; } = new List<User.User>();
    }

    public enum RoleType : short
    {
        [Display(Name = "ادمین")]
        Admin,

        [Display(Name = "فروشنده")]
        Seller,

        [Display(Name = "کاربر")]
        User
    }
}
