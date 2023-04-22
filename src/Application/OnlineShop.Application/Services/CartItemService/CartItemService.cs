using OnlineShop.Application.Core.Services.CartItemService;
using OnlineShop.Application.Core.Services.CartItemService.Dtos;
using OnlineShop.Application.Mapping;
using OnlineShop.Data.Core;
using OnlineShop.Data.Core.Repositories;
using OnlineShop.Domain.Entities.Cart;

namespace OnlineShop.Application.Services.CartItemService
{
    public class CartItemService : ApplicationService<Guid, CartItem, CartItemInputDto, CartItemUpdateDto, CartItemOutputDto, CartItemSPFInputDto>, ICartItemService
    {
        public CartItemService(IMapping mapping, IRepository<CartItem, Guid> repository, IUnitOfWork unitOfWork) : base(mapping, repository, unitOfWork)
        {
        }

        public override void RunSPFFilter(ref IQueryable<CartItem> qry, CartItemSPFInputDto model)
        {
            qry = qry.Where(x=> x.CartId == model.CartId);

            base.RunSPFFilter(ref qry, model);
        }
    }
}
