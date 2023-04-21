using AutoMapper;
using OnlineShop.Application.Core.Services.ProductDetailKeyValueService.Dtos;
using OnlineShop.Domain.Entities.Product;

namespace OnlineShop.Application.Core.Services.ProductDetailKeyValueService.MappingProfiles
{
    public class ProductDetailKeyValueMap : Profile
    {
        public ProductDetailKeyValueMap()
        {
            CreateMap<ProductDetailKeyValueInputDto, ProductDetailKeyValue>();
        }
    }
}
