using OnlineShop.Application.Core.Services.AddressService.Dtos;
using OnlineShop.Domain.Entities.User;

namespace OnlineShop.Application.Core.Services.AddressService
{
    public interface IAddressService : IApplicationService<Guid, Address, AddressInputDto, AddressUpdateDto, AddressOutputDto, AddressSPFInputDto>
    {
    }
}
