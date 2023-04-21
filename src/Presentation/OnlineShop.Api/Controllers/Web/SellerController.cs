using OnlineShop.Application.Core.Services.SellerService;
using OnlineShop.Application.Core.Services.SellerService.Dtos;
using OnlineShop.Domain.Entities.User;

namespace OnlineShop.Api.Controllers.Web
{
    public class SellerController : BaseApiController<long, Seller, SellerInputDto, SellerUpdateDto, SellerOutputDto>
    {
        public SellerController(ISellerService service) : base(service)
        {
        }
    }
}
