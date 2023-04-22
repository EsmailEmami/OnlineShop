using OnlineShop.Common.Dtos;

namespace OnlineShop.Application.Core.Services.AddressService.Dtos
{
    public class AddressSPFInputDto : SPFInputDto
    {
        public long UserId { get; set; }
    }
}
