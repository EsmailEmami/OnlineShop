using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Core.Services.CartService;
using OnlineShop.Application.Core.Services.CartService.Dtos;
using OnlineShop.Domain.Entities.Cart;

namespace OnlineShop.Api.Controllers.Web
{
    public class CartController : BaseApiController<Guid, Cart, CartInputDto, CartUpdateDto, CartOutputDto, CartSPFInputDto>
    {
        private readonly ICartService _cartService;
        public CartController(ICartService service) : base(service)
        {
            _cartService = service;
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public IActionResult WithItems([FromRoute] Guid id)
        {
            return Ok(_cartService.GetWithItems(id));
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public IActionResult WithDetail([FromRoute] Guid id)
        {
            return Ok(_cartService.GetWithDetail(id));
        }
    }
}
