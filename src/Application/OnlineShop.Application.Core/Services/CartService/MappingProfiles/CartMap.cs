using AutoMapper;
using OnlineShop.Application.Core.Services.CartItemService.Dtos;
using OnlineShop.Application.Core.Services.CartService.Dtos;
using OnlineShop.Common.Extensions;
using OnlineShop.Domain.Entities.Cart;

namespace OnlineShop.Application.Core.Services.CartService.MappingProfiles
{
    public class CartMap : Profile
    {
        public CartMap()
        {
            CreateMap<Cart, CartOutputDto>()
                .ForMember(x => x.CartStateName, opt => opt.MapFrom(x => x.CartState.GetDisplayName()))
                .ForMember(x => x.CreateDate, opt => opt.MapFrom(x => x.CreateDate.ToFa()));

            CreateMap<CartInputDto, Cart>();
        }
    }
}
