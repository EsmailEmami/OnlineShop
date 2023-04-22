using OnlineShop.Application.Core.Services.StateService.Dtos;
using OnlineShop.Domain.Entities.User;

namespace OnlineShop.Application.Core.Services.StateService
{
    public interface IStateService : IApplicationService<int, State, StateInputDto, StateUpdateDto, StateOutputDto>
    {
    }
}
