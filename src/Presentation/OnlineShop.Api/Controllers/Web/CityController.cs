using OnlineShop.Application.Core.Services.CityService;
using OnlineShop.Application.Core.Services.CityService.Dtos;
using OnlineShop.Domain.Entities.User;

namespace OnlineShop.Api.Controllers.Web
{
    public class CityController : BaseApiController<int, City, CityInputDto, CityUpdateDto, CityOutputDto>
    {
        public CityController(ICityService service) : base(service)
        {
        }
    }
}
