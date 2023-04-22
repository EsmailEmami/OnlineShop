using AutoMapper;
using OnlineShop.Application.Core.Services.ProductService.Dtos;
using OnlineShop.Domain.Entities.Product;

namespace OnlineShop.Application.Core.Services.ProductService.MappingProfiles
{
    public class ProductMap : Profile
    {
        public ProductMap()
        {
            CreateMap<ProductInputDto, Product>();
            CreateMap<ProductUpdateDto, Product>();
            CreateMap<Product, ProductOutputDto>()
                .ForMember(x => x.PicPath, opt => opt.MapFrom(x => x.Pics.Any(v => v.IsMain) ? x.Pics.First(v => v.IsMain).PeyvastFile.FileName : null))
                .ForMember(x => x.Price, opt => opt.MapFrom(x => x.Items.Any() ? x.Items.First().Price : 0));

            CreateMap<Product, ProductDetailOutputDto>()
                .ForMember(x => x.ProductTypeName, opt => opt.MapFrom(x => x.ProductType.Name))
                .ForMember(x => x.CompanyName, opt => opt.MapFrom(x => x.Company.Name))
                .ForMember(x => x.Pics, opt => opt.MapFrom(x => x.Pics.Select(v => v.PeyvastFile.FileName)));
        }
    }
}
