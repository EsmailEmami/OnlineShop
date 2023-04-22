using OnlineShop.Application.Core.Services.SelectListService;
using OnlineShop.Application.Core.Services.SelectListService.Dtos;
using OnlineShop.Application.Mapping;
using OnlineShop.Data.Core;
using OnlineShop.Data.Core.Repositories;
using OnlineShop.Domain.Entities.System;

namespace OnlineShop.Application.Services.SelectListService
{
    public class SelectListService : ApplicationService<int, SelectList, SelectListInputDto, SelectListUpdateDto, SelectListOutputDto>, ISelectListService
    {
        public SelectListService(IMapping mapping, IRepository<SelectList, int> repository, IUnitOfWork unitOfWork) : base(mapping, repository, unitOfWork)
        {
        }
    }
}
