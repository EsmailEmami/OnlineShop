using OnlineShop.Application.Core.Services.CartService;
using OnlineShop.Application.Core.Services.CartService.Dtos;
using OnlineShop.Application.Mapping;
using OnlineShop.Data.Core;
using OnlineShop.Data.Core.Repositories;
using OnlineShop.Domain.Entities.Cart;

namespace OnlineShop.Application.Services.CartService
{
    public class CartService : ApplicationService<Guid, Cart, CartInputDto, CartUpdateDto, CartOutputDto, CartSPFInputDto>, ICartService
    {
        public CartService(IMapping mapping, IRepository<Cart, Guid> repository, IUnitOfWork unitOfWork) : base(mapping, repository, unitOfWork)
        {
        }

        public CartDetailInputDto GetWithDetail(Guid id)
        {
            return _mapping.Map<Cart, CartDetailInputDto>(_repository.Get(id));
        }

        public CartWithItemsOutputDto GetWithItems(Guid id)
        {
            return _mapping.Map<Cart, CartWithItemsOutputDto>(_repository.Get(id));
        }

        public override void RunSPFFilter(ref IQueryable<Cart> qry, CartSPFInputDto model)
        {
            if (model.BiggerThanState)
            {
                qry = qry.Where(c => c.CartState >= model.CartState);
            }
            else
            {
                qry = qry.Where(x => x.CartState == model.CartState);
            }

            if (model.UserId.HasValue)
            {
                qry = qry.Where(x => x.UserId == model.UserId);
            }

            base.RunSPFFilter(ref qry, model);
        }
    }
}
