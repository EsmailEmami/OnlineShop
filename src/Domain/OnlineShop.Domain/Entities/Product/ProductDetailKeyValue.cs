using OnlineShop.Domain.Core;

namespace OnlineShop.Domain.Entities.Product
{
    public class ProductDetailKeyValue : Entity
    {
        public int ProductDetailKeyId { get; set; }
        public virtual ProductDetailKey ProductDetailKey { get; set; }

        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }

        public string Value { get; set; }
    }
}
