using OnlineShop.Application.Core.Services.CartService;
using OnlineShop.Application.Core.Services.CartService.Dtos;
using OnlineShop.Application.Mapping;
using OnlineShop.Data.Core;
using OnlineShop.Data.Core.Repositories;
using OnlineShop.Domain.Entities.Cart;

namespace OnlineShop.Application.Services.CartService
{
    public class CartService : ApplicationService<Guid, Cart, CartInputDto, CartUpdateDto, CartOutputDto>, ICartService
    {
        public CartService(IMapping mapping, IRepository<Cart, Guid> repository, IUnitOfWork unitOfWork) : base(mapping, repository, unitOfWork)
        {
        }
    }
}
