using OnlineShop.Domain.Core;
using OnlineShop.Domain.Entities.Cart;
using OnlineShop.Domain.Entities.System;

namespace OnlineShop.Domain.Entities.Product
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public int ProductTypeId { get; set; }
        public virtual ProductType ProductType { get; set; }

        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        public virtual ICollection<ProductDetailKeyValue> ProductDetailKeyValues { get; set; } = new List<ProductDetailKeyValue>();

        public virtual ICollection<ProductItem> Items { get; set; } = new List<ProductItem>();
        public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
        public virtual ICollection<ProductPeyvastFile> Pics { get; set; } = new List<ProductPeyvastFile>();

        public bool IsActive { get; set; }
    }
}
