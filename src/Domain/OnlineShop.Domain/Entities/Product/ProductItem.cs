using OnlineShop.Domain.Core;
using OnlineShop.Domain.Entities.System;

namespace OnlineShop.Domain.Entities.Product
{
    public class ProductItem : Entity
    {
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int ColorId { get; set; }
        public virtual SelectList Color { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public virtual ICollection<ProductItemSeller> Sellers { get; set; } = new List<ProductItemSeller>();
    }
}
