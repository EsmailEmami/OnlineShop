using OnlineShop.Application.Core.Services.CartService;
using OnlineShop.Application.Core.Services.CartService.Dtos;
using OnlineShop.Domain.Entities.Cart;

namespace OnlineShop.Api.Controllers.Web
{
    public class CartController : BaseApiController<Guid, Cart, CartInputDto, CartUpdateDto, CartOutputDto>
    {
        public CartController(ICartService service) : base(service)
        {
        }
    }
}
