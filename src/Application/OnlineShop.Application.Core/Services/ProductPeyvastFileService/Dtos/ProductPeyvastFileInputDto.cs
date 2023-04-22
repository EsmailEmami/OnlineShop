using OnlineShop.Domain.Entities.Product;
using OnlineShop.Domain.Entities.System;

namespace OnlineShop.Application.Core.Services.ProductPeyvastFileService.Dtos
{
    public class ProductPeyvastFileInputDto
    {
        public Guid ProductId { get; set; }
        public Guid PeyvastFileId { get; set; } = Guid.Empty;
        public bool IsVisiable { get; set; }
        public bool IsMain { get; set; }
        public short Priority { get; set; }
    }
}
