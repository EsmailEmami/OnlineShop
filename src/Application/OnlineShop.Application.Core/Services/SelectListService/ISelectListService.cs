using OnlineShop.Application.Core.Services.SelectListService.Dtos;
using OnlineShop.Domain.Entities.System;

namespace OnlineShop.Application.Core.Services.SelectListService
{
    public interface ISelectListService : IApplicationService<int, SelectList, SelectListInputDto, SelectListUpdateDto, SelectListOutputDto>
    {
    }
}
