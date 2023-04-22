using OnlineShop.Application.Core.Services.CartService;
using OnlineShop.Application.Core.Services.CartService.Dtos;
using OnlineShop.Application.Mapping;
using OnlineShop.Data.Core;
using OnlineShop.Data.Core.Repositories;
using OnlineShop.Domain.Entities.Cart;
using OnlineShop.Domain.Identity;

namespace OnlineShop.Application.Services.CartService
{
    public class CartService : ApplicationService<Guid, Cart, CartInputDto, CartUpdateDto, CartOutputDto, CartSPFInputDto>, ICartService
    {
        private readonly IUser _user;
        public CartService(IMapping mapping, IRepository<Cart, Guid> repository, IUnitOfWork unitOfWork, IUser user) : base(mapping, repository, unitOfWork)
        {
            _user = user;
        }

        public override Task<Guid> CreateAsync(CartInputDto inputDto)
        {
            inputDto.UserId = _user.UserId;
            return base.CreateAsync(inputDto);
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
