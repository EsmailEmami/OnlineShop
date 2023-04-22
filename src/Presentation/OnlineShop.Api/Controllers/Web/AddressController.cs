using OnlineShop.Application.Core.Services.AddressService;
using OnlineShop.Application.Core.Services.AddressService.Dtos;
using OnlineShop.Domain.Entities.User;

namespace OnlineShop.Api.Controllers.Web
{
    public class AddressController : BaseApiController<Guid, Address, AddressInputDto, AddressUpdateDto, AddressOutputDto, AddressSPFInputDto>
    {
        public AddressController(IAddressService service) : base(service)
        {
        }
    }
}
