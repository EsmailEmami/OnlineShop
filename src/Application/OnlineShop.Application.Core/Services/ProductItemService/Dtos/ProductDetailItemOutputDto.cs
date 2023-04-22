using OnlineShop.Application.Core.Services.ProductItemSellerService.Dtos;
using OnlineShop.Application.Core.Services.SelectListService.Dtos;

namespace OnlineShop.Application.Core.Services.ProductItemService.Dtos
{
    public class ProductDetailItemOutputDto
    {
        public Guid Id { get; set; }
        public SelectListOutputDto Color { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public IList<ProductDetailSellerOutputDto> Sellers { get; set; } = new List<ProductDetailSellerOutputDto>();
    }
}
