using AutoMapper;
using OnlineShop.Application.Core.Services.SellerService.Dtos;
using OnlineShop.Domain.Entities.User;

namespace OnlineShop.Application.Core.Services.SellerService.MappingProfiles
{
    public class SellerMap : Profile
    {
        public SellerMap()
        {
            CreateMap<SellerInputDto, Seller>()
                 .ForMember(x => x.Id, opt => opt.MapFrom(x => x.UserId));

            CreateMap<SellerUpdateDto, Seller>();

            CreateMap<Seller, SellerOutputDto>()
                .ForMember(x => x.FirstName, opt => opt.MapFrom(x => x.User.FirstName))
                .ForMember(x => x.LastName, opt => opt.MapFrom(x => x.User.LastName))
                .ForMember(x => x.UserName, opt => opt.MapFrom(x => x.User.UserName))
                .ForMember(x => x.PhoneNumber, opt => opt.MapFrom(x => x.User.PhoneNumber));

        }
    }
}
