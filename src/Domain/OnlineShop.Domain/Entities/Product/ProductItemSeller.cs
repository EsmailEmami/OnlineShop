using OnlineShop.Domain.Core;

namespace OnlineShop.Domain.Entities.Product
{
    public class ProductItemSeller : Entity
    {
        public Guid ProductItemId { get; set; }
        public virtual ProductItem ProductItem { get; set; }

        public long SellerId { get; set; }
        public virtual User.Seller Seller { get; set; }

        public double Quantity { get; set; }

        public bool IsActive { get; set; }
    }
}
