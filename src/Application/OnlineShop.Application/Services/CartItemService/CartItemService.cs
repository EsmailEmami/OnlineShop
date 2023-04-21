using OnlineShop.Application.Core.Services.CartItemService;
using OnlineShop.Application.Core.Services.CartItemService.Dtos;
using OnlineShop.Application.Mapping;
using OnlineShop.Data.Core;
using OnlineShop.Data.Core.Repositories;
using OnlineShop.Domain.Entities.Cart;

namespace OnlineShop.Application.Services.CartItemService
{
    public class CartItemService : ApplicationService<Guid, CartItem, CartItemInputDto, CartItemUpdateDto, CartItemOutputDto>, ICartItemService
    {
        public CartItemService(IMapping mapping, IRepository<CartItem, Guid> repository, IUnitOfWork unitOfWork) : base(mapping, repository, unitOfWork)
        {
        }
    }
}
