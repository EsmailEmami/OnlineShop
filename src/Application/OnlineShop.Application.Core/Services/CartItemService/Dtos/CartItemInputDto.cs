using OnlineShop.Domain.Entities.Cart;
using OnlineShop.Domain.Entities.Discount;
using OnlineShop.Domain.Entities.Product;

namespace OnlineShop.Application.Core.Services.CartItemService.Dtos
{
    public class CartItemInputDto
    {
        public Guid CartId { get; set; }
        public double Quantity { get; set; } = 1;
        public Guid ProductItemId { get; set; }
        public Guid SellerId { get; set; }
    }
}
