using AutoMapper;
using OnlineShop.Application.Core.Services.ProductDetailKeyService.Dtos;
using OnlineShop.Application.Core.Services.ProductDetailKeyValueService.Dtos;
using OnlineShop.Domain.Entities.Product;

namespace OnlineShop.Application.Core.Services.ProductDetailKeyValueService.MappingProfiles
{
    public class ProductDetailKeyValueMap : Profile
    {
        public ProductDetailKeyValueMap()
        {
            CreateMap<ProductDetailKeyValueInputDto, ProductDetailKeyValue>();
            CreateMap<ProductDetailKeyValueUpdateDto, ProductDetailKeyValue>();
            CreateMap<ProductDetailKeyValue, ProductDetailKeyOutputDto>()
                .ForMember(x => x.Key, opt => opt.MapFrom(x => x.ProductDetailKey.Key));
            
            CreateMap<ProductDetailKeyValue, ProductDetailKeyValueShowOutputDto>()
                .ForMember(x => x.Key, opt => opt.MapFrom(x => x.ProductDetailKey.Key));
        }
    }
}
