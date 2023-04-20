using OnlineShop.Domain.Core;

namespace OnlineShop.Domain.Entities.User
{
    public class Address : Entity
    {
        public long UserId { get; set; }
        public virtual User User { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        public int CityId { get; set; }
        public virtual City City { get; set; }

        public string Plaque { get; set; }
        public string PostalCode { get; set; }
        public string AddressText { get; set; }

        public virtual ICollection<Cart.Cart> Carts { get; set; } = new List<Cart.Cart>();
    }
}
