using OnlineShop.Domain.Core;
using OnlineShop.Domain.Entities.Product;

namespace OnlineShop.Domain.Entities.User
{
    public class Seller : Entity<long>
    {
        public virtual User User { get; set; }

        public string StoreName { get; set; }

        public virtual ICollection<ProductItemSeller> Products { get; set; } = new List<ProductItemSeller>();
    }
}
