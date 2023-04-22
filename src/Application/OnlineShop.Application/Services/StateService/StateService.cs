using OnlineShop.Application.Core.Services.StateService;
using OnlineShop.Application.Core.Services.StateService.Dtos;
using OnlineShop.Application.Mapping;
using OnlineShop.Data.Core;
using OnlineShop.Data.Core.Repositories;
using OnlineShop.Domain.Entities.User;

namespace OnlineShop.Application.Services.StateService
{
    public class StateService : ApplicationService<int, State, StateInputDto, StateUpdateDto, StateOutputDto>, IStateService
    {
        public StateService(IMapping mapping, IRepository<State, int> repository, IUnitOfWork unitOfWork) : base(mapping, repository, unitOfWork)
        {
        }
    }
}
