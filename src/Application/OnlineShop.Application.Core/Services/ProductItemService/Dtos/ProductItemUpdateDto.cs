using OnlineShop.Application.Core.Services.ProductItemSellerService.Dtos;

namespace OnlineShop.Application.Core.Services.ProductItemService.Dtos
{
    public class ProductItemUpdateDto
    {
        public int ColorId { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public virtual ICollection<ProductItemSellerInputDto> Sellers { get; set; } = new List<ProductItemSellerInputDto>();
    }
}
