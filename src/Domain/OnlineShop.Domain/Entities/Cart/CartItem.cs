using OnlineShop.Common.Generator;
using OnlineShop.Domain.Core;
using OnlineShop.Domain.Entities.Discount;
using OnlineShop.Domain.Entities.Product;

namespace OnlineShop.Domain.Entities.Cart
{
    public class CartItem : Entity
    {
        public CartItem()
        {
            TrackingCode = "RSD-" + NumGenerator.GenerateNumber();
        }
        public Guid CartId { get; set; }
        public virtual Cart Cart { get; set; }
        public string TrackingCode { get; protected set; }
        public double Quantity { get; set; } = 1;

        public Guid ProductItemId { get; set; }
        public virtual ProductItem ProductItem { get; set; }

        public Guid SellerId { get; set; }
        public virtual ProductItemSeller Seller { get; set; }

        // this items are for cache, while order state is payed
        public decimal Price { get; set; } = 0;
        public long? DiscountId { get; set; }
        public virtual ProductDiscount Discount { get; set; }
        public decimal Sum
        {
            get
            {
                if (Cart.CartState >= CartState.Payed)
                    return Price * (decimal)Quantity;

                return ProductItem.Price * (decimal)Quantity;
            }
        }
    }
}
