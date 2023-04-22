using OnlineShop.Application.Core.Services.StateService;
using OnlineShop.Application.Core.Services.StateService.Dtos;
using OnlineShop.Domain.Entities.User;

namespace OnlineShop.Api.Controllers.Web
{
    public class StateController : BaseApiController<int, State, StateInputDto, StateUpdateDto, StateOutputDto>
    {
        public StateController(IStateService service) : base(service)
        {
        }
    }
}
