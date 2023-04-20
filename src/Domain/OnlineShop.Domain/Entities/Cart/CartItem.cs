using OnlineShop.Domain.Core;
using OnlineShop.Domain.Entities.Discount;
using OnlineShop.Domain.Entities.Product;

namespace OnlineShop.Domain.Entities.Cart
{
    public class CartItem : Entity
    {
        public Guid CartId { get; set; }
        public virtual Cart Cart { get; set; }
        public string TrackingCode { get; set; }
        public double Quantity { get; set; }

        public Guid ProductId { get; set; }
        public virtual Product.Product Product { get; set; }

        // this items are for cache, while order state is payed
        public decimal Price { get; set; }
        public long? DiscountId { get; set; }
        public virtual ProductDiscount Discount { get; set; }
        public decimal Sum { get; set; }
    }
}
