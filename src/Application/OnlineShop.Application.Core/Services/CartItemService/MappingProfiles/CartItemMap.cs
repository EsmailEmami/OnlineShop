using AutoMapper;
using OnlineShop.Application.Core.Services.CartItemService.Dtos;
using OnlineShop.Domain.Entities.Cart;

namespace OnlineShop.Application.Core.Services.CartItemService.MappingProfiles
{
    public class CartItemMap : Profile
    {
        public CartItemMap()
        {
            CreateMap<CartItemInputDto, CartItem>();
            CreateMap<CartItem, CartItemOutputDto>()
                   .ForMember(x => x.ProductName, opt => opt.MapFrom(x => x.ProductItem.Product.Name))
                   .ForMember(x => x.ProductId, opt => opt.MapFrom(x => x.ProductItem.ProductId))
                   .ForMember(x => x.Color, opt => opt.MapFrom(x => x.ProductItem.Color))
                   .ForMember(x => x.StoreName, opt => opt.MapFrom(x => x.Seller.Seller.StoreName))
                   .ForMember(x => x.SellerId, opt => opt.MapFrom(x => x.Seller.SellerId));
        }
    }
}
