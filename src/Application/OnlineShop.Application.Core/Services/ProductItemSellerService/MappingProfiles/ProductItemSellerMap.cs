using AutoMapper;
using OnlineShop.Application.Core.Services.ProductItemSellerService.Dtos;
using OnlineShop.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Core.Services.ProductItemSellerService.MappingProfiles
{
    public class ProductItemSellerMap : Profile
    {
        public ProductItemSellerMap()
        {
            CreateMap<ProductItemSellerInputDto, ProductItemSeller>();
            CreateMap<ProductItemSellerUpdateDto, ProductItemSeller>();
            CreateMap<ProductItemSeller, ProductItemSellerOutputDto>()
                .ForMember(x => x.ProductId, opt => opt.MapFrom(x => x.ProductItem.ProductId))
                .ForMember(x => x.ProductName, opt => opt.MapFrom(x => x.ProductItem.Product.Name))
                .ForMember(x => x.StoreName, opt => opt.MapFrom(x => x.Seller.StoreName))
                .ForMember(x => x.SellerFirstName, opt => opt.MapFrom(x => x.Seller.User.FirstName))
                .ForMember(x => x.SellerLastName, opt => opt.MapFrom(x => x.Seller.User.LastName))
                .ForMember(x => x.SellerUserName, opt => opt.MapFrom(x => x.Seller.User.UserName))
                .ForMember(x => x.SellerPhoneNumber, opt => opt.MapFrom(x => x.Seller.User.PhoneNumber));
        }
    }
}
