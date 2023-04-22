using OnlineShop.Application.Core.Services.CityService;
using OnlineShop.Application.Core.Services.CityService.Dtos;
using OnlineShop.Application.Mapping;
using OnlineShop.Data.Core;
using OnlineShop.Data.Core.Repositories;
using OnlineShop.Domain.Entities.User;

namespace OnlineShop.Application.Services.CityService
{
    public class CityService : ApplicationService<int, City, CityInputDto, CityUpdateDto, CityOutputDto>, ICityService
    {
        public CityService(IMapping mapping, IRepository<City, int> repository, IUnitOfWork unitOfWork) : base(mapping, repository, unitOfWork)
        {
        }
    }
}
