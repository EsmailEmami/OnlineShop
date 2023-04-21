using OnlineShop.Application.Core.Services.ProductItemSellerService.Dtos;
using OnlineShop.Domain.Entities.Product;
using OnlineShop.Domain.Entities.System;

namespace OnlineShop.Application.Core.Services.ProductItemService.Dtos
{
    public class ProductItemInputDto
    {
        public Guid ProductId { get; set; }
        public int ColorId { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public virtual ICollection<ProductItemSellerInputDto> Sellers { get; set; } = new List<ProductItemSellerInputDto>();
    }
}
