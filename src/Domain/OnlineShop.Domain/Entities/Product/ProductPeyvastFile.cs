using OnlineShop.Domain.Core;
using OnlineShop.Domain.Entities.System;

namespace OnlineShop.Domain.Entities.Product
{
    public class ProductPeyvastFile : Entity
    {
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }

        public Guid PeyvastFileId { get; set; }
        public virtual PeyvastFile PeyvastFile { get; set; }

        public bool IsVisiable { get; set; }
        public bool IsMain { get; set; }
        public short Priority { get; set; }
    }
}
