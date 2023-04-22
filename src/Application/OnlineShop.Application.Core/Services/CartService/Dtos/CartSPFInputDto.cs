using OnlineShop.Common.Dtos;
using OnlineShop.Domain.Entities.Cart;

namespace OnlineShop.Application.Core.Services.CartService.Dtos
{
    public class CartSPFInputDto : SPFInputDto
    {
        public CartState CartState { get; set; } = CartState.Payed;
        public bool BiggerThanState { get; set; } = false;
        public long? UserId { get; set; }
    }
}
