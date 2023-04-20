using OnlineShop.Domain.Core;

namespace OnlineShop.Domain.Entities.Product
{
    public class ProductDetailKey : Entity<int>
    {
        public int ProductTypeId { get; set; }
        public virtual ProductType ProductType { get; set; }

        public string Key { get; set; }

        public virtual ICollection<ProductDetailKeyValue> ProductDetailKeyValues { get; set; } = new List<ProductDetailKeyValue>();
    }
}
