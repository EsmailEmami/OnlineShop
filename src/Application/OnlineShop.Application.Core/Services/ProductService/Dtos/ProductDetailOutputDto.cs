using OnlineShop.Application.Core.Services.ProductDetailKeyService.Dtos;
using OnlineShop.Application.Core.Services.ProductDetailKeyValueService.Dtos;
using OnlineShop.Application.Core.Services.ProductItemService.Dtos;

namespace OnlineShop.Application.Core.Services.ProductService.Dtos
{
    public class ProductDetailOutputDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProductTypeId { get; set; }
        public string ProductTypeName { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public IList<string> Pics { get; set; }

        public IList<ProductDetailKeyValueShowOutputDto> ProductDetailKeyValues { get; set; } = new List<ProductDetailKeyValueShowOutputDto>();

        public IList<ProductDetailItemOutputDto> Items { get; set; } = new List<ProductDetailItemOutputDto>();

    }
}
