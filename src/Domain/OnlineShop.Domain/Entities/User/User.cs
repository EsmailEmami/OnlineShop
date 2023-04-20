using OnlineShop.Domain.Core;
using OnlineShop.Domain.Entities.Discount;
using OnlineShop.Domain.Entities.Permission;

namespace OnlineShop.Domain.Entities.User
{
    public class User : Entity<long>
    {
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

        public long? SellerId { get; set; }
        public virtual Seller Seller { get; set; }

        public int RoleId { get; set; }
        public virtual Role Role { get; set; }

        public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();
        public virtual ICollection<DiscountUser> DiscountUsers { get; set; } = new List<DiscountUser>();
        public virtual ICollection<Cart.Cart> Carts { get; set; } = new List<Cart.Cart>();

    }
}
