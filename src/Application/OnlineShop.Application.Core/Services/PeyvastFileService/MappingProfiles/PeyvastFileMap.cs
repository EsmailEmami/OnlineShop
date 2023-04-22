using AutoMapper;
using OnlineShop.Application.Core.Services.PeyvastFileService.Dtos;
using OnlineShop.Domain.Entities.System;

namespace OnlineShop.Application.Core.Services.PeyvastFileService.MappingProfiles
{
    public class PeyvastFileMap : Profile
    {
        public PeyvastFileMap()
        {
            CreateMap<PeyvastFile, PeyvastFileOutputDto>();
        }
    }
}
