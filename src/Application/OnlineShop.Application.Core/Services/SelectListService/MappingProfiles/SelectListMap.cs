using AutoMapper;
using OnlineShop.Application.Core.Services.SelectListService.Dtos;
using OnlineShop.Common.Extensions;
using OnlineShop.Domain.Entities.System;

namespace OnlineShop.Application.Core.Services.SelectListService.MappingProfiles
{
    public class SelectListMap : Profile
    {
        public SelectListMap()
        {
            CreateMap<SelectListInputDto, SelectList>();
            CreateMap<SelectListUpdateDto, SelectList>();
            CreateMap<SelectList, SelectListOutputDto>()
                 .ForMember(x => x.SelectListTypeName, opt => opt.MapFrom(x => x.SelectListType.GetDisplayName()));
        }
    }
}
