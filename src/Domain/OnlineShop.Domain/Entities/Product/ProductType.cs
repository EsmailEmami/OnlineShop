using OnlineShop.Domain.Core;

namespace OnlineShop.Domain.Entities.Product
{
    public class ProductType : Entity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
        public virtual ICollection<ProductDetailKey> ProductDetailKeys { get; set; } = new List<ProductDetailKey>();
    }
}
