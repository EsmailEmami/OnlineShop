using OnlineShop.Application.Core.Services.CartService.Dtos;
using OnlineShop.Common.Dtos;
using OnlineShop.Domain.Entities.Cart;

namespace OnlineShop.Application.Core.Services.CartService
{
    public interface ICartService : IApplicationService<Guid, Cart, CartInputDto, CartUpdateDto, CartOutputDto, CartSPFInputDto>
    {
        CartWithItemsOutputDto GetWithItems(Guid id);
        CartDetailInputDto GetWithDetail(Guid id);
    }
}
