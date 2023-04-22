using OnlineShop.Application.Core.Services.CartItemService.Dtos;
using OnlineShop.Domain.Entities.Cart;

namespace OnlineShop.Application.Core.Services.CartService.Dtos
{
    public class CartInputDto
    {
        public CartState CartState { get; set; } = CartState.Open;
        public long UserId { get; set; }
        public Guid? AddressId { get; set; }
        public IList<CartItemInputDto> CartItems { get; set; } = new List<CartItemInputDto>();
    }
}
