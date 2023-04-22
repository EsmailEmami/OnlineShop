using OnlineShop.Application.Core.Services.CartItemService;
using OnlineShop.Application.Core.Services.CartItemService.Dtos;
using OnlineShop.Domain.Entities.Cart;

namespace OnlineShop.Api.Controllers.Web
{
    public class CartItemController : BaseApiController<Guid, CartItem, CartItemInputDto, CartItemUpdateDto, CartItemOutputDto, CartItemSPFInputDto>
    {
        public CartItemController(ICartItemService service) : base(service)
        {
        }
    }
}
