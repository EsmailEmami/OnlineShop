using OnlineShop.Domain.Entities.Product;
using OnlineShop.Domain.Entities.User;

namespace OnlineShop.Application.Core.Services.ProductItemSellerService.Dtos
{
    public class ProductDetailSellerOutputDto
    {
        public long SellerId { get; set; }
        public string StoreName { get; set; }
        public double Quantity { get; set; }
    }
}
