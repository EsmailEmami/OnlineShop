using OnlineShop.Application.Core.Services.ProductDetailKeyValueService.Dtos;
using OnlineShop.Application.Core.Services.ProductItemService.Dtos;

namespace OnlineShop.Application.Core.Services.ProductService.Dtos
{
    public class ProductInputDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProductTypeId { get; set; }
        public int CompanyId { get; set; }
        public virtual ICollection<ProductDetailKeyValueInputDto> ProductDetailKeyValues { get; set; } = new List<ProductDetailKeyValueInputDto>();
        public virtual ICollection<ProductItemInputDto> Items { get; set; } = new List<ProductItemInputDto>();
        public bool IsActive { get; set; }
    }
}
