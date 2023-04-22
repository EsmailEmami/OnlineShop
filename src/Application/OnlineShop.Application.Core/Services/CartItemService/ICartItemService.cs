using OnlineShop.Application.Core.Services.CartItemService.Dtos;
using OnlineShop.Domain.Entities.Cart;

namespace OnlineShop.Application.Core.Services.CartItemService
{
    public interface ICartItemService : IApplicationService<Guid, CartItem, CartItemInputDto, CartItemUpdateDto, CartItemOutputDto, CartItemSPFInputDto>
    {
    }
}
