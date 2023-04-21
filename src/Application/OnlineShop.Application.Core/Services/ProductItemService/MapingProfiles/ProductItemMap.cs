using AutoMapper;
using OnlineShop.Application.Core.Services.ProductItemService.Dtos;
using OnlineShop.Domain.Entities.Product;

namespace OnlineShop.Application.Core.Services.ProductItemService.MapingProfiles
{
    public class ProductItemMap : Profile
    {
        public ProductItemMap()
        {
            CreateMap<ProductItemInputDto, ProductItem>();
            CreateMap<ProductItemUpdateDto, ProductItem>();
            CreateMap<ProductItem, ProductItemOutputDto>();
        }
    }
}
