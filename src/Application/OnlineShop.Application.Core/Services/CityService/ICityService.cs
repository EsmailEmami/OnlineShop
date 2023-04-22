using OnlineShop.Application.Core;
using OnlineShop.Application.Core.Services.CityService.Dtos;
using OnlineShop.Domain.Entities.User;

namespace OnlineShop.Application.Core.Services.CityService
{
    public interface ICityService : IApplicationService<int, City, CityInputDto, CityUpdateDto, CityOutputDto>
    {
    }
}
